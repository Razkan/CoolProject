using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library.Communication.Converter
{
    public class InterfaceConverterImpl<T> : JsonConverter<T>
    {
        private Type IsEnumerable { get; } = typeof(IEnumerable);

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dict = ParseDictionary(ref reader, options);
            var obj = Build(dict, null);

            var resultType = typeof(T);
            var trackedResultType = typeof(TrackedResult<>);
            var constructedTrackedResult = trackedResultType.MakeGenericType(resultType.GetGenericArguments());
            var result = Activator.CreateInstance(constructedTrackedResult, obj);

            return (T) result;
        }

        public object Build(Dictionary<string, object> jsonStructure, Type[] propertyTypeGenericTypeArguments)
        {
            if (jsonStructure.ContainsKey("__Type__"))
            {
                var type = jsonStructure["__Type__"];
                var instanceType = Type.GetType(type.ToString());
                if (instanceType == null) return null;

                object instance;
                if (instanceType.IsArray)
                {
                    if (propertyTypeGenericTypeArguments.Length > 1)
                        throw new Exception("Only handling of one generic array type allowed");

                    var listType = typeof(List<>);
                    var constructedListType = listType.MakeGenericType(propertyTypeGenericTypeArguments);
                    instance = Activator.CreateInstance(constructedListType);
                }
                else
                {
                    instance = Activator.CreateInstance(instanceType);
                }

                foreach (var (key, value) in jsonStructure)
                {
                    var pi = instanceType.GetProperty(key);

                    switch (value)
                    {
                        case Dictionary<string, object> dict:
                        {
                            var obj = Build(dict, pi?.PropertyType.GenericTypeArguments);
                            pi?.SetValue(instance, obj);
                        }
                            break;

                        case List<object> list:
                        {
                            var typeArgument = propertyTypeGenericTypeArguments[0];
                            Build(list, (IList) instance, typeArgument);
                        }
                            break;

                        case long v when pi != null && pi.PropertyType.IsEnum:
                        {
                            pi.SetValue(instance, Enum.ToObject(pi.PropertyType, v));
                        }
                            break;

                        default:
                        {
                            if (IsAutoProperty(pi))
                            {
                                pi?.SetValue(instance, value);
                            }
                        }
                            break;
                    }
                }

                return instance;
            }


            return default;
        }

        private void Build(IEnumerable<object> list, IList instance, Type instanceType)
        {
            foreach (var obj in list)
            {
                switch (obj)
                {
                    case Dictionary<string, object> dict:
                    {
                        instance.Add(Build(dict, null));
                    }
                        break;

                    case long @enum when instanceType.IsEnum:
                    {
                        var value = Enum.ToObject(instanceType, @enum);
                        instance.Add(value);
                    }
                        break;

                    case long l:
                    {
                        instance.Add(l);
                    }
                        break;

                    default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        public Dictionary<string, object> ParseDictionary(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException($"JsonTokenType was of type {reader.TokenType}, only objects are supported");
            }

            var dictionary = new Dictionary<string, object>();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return dictionary;
                }

                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException("JsonTokenType was not PropertyName");
                }

                var propertyName = reader.GetString();

                if (string.IsNullOrWhiteSpace(propertyName))
                {
                    throw new JsonException("Failed to get property name");
                }

                reader.Read();

                dictionary.Add(propertyName, ExtractValue(ref reader, options));
            }

            return dictionary;
        }

        private object ExtractValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    if (reader.TryGetDateTime(out var date))
                    {
                        return date;
                    }

                    return reader.GetString();
                case JsonTokenType.False:
                    return false;
                case JsonTokenType.True:
                    return true;
                case JsonTokenType.Null:
                    return null;
                case JsonTokenType.Number:
                    if (reader.TryGetInt64(out var result))
                    {
                        return result;
                    }

                    return reader.GetDecimal();
                case JsonTokenType.StartObject:
                    return ParseDictionary(ref reader, options);
                case JsonTokenType.StartArray:
                    var list = new List<object>();
                    while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                    {
                        list.Add(ExtractValue(ref reader, options));
                    }

                    return list;
                default:
                    throw new JsonException($"'{reader.TokenType}' is not supported");
            }
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var type = value.GetType();
            if (IsEnumerable.IsAssignableFrom(type))
            {
                writer.WriteStartObject();
                WriteArray(writer, value, options);
                writer.WriteEndObject();
            }
            else
            {
                writer.WriteStartObject();
                WriteObject(writer, value, type, options);
                writer.WriteEndObject();
            }
        }


        private void WriteObject(Utf8JsonWriter writer, object value, Type type, JsonSerializerOptions options)
        {
            if (value == null)
                return;

            writer.WriteString("__Type__", type.AssemblyQualifiedName);

            foreach (var property in type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance |
                                                        BindingFlags.Public))
            {
                writer.WritePropertyName(property.Name);
                if (property.PropertyType.IsInterface)
                {
                    if (IsEnumerable.IsAssignableFrom(property.PropertyType))
                    {
                        writer.WriteStartObject();
                        WriteArray(writer, property.GetValue(value), options);
                        writer.WriteEndObject();
                    }
                    else
                    {
                        writer.WriteStartObject();
                        WriteObject(writer, property.GetValue(value), property.PropertyType, options);
                        writer.WriteEndObject();
                    }
                }
                else
                {
                    JsonSerializer.Serialize(writer, property.GetValue(value), options);
                }
            }
        }

        private void WriteArray(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            if (value == null)
                return;

            var type = value.GetType();
            writer.WriteString("__Type__", type.AssemblyQualifiedName);
            writer.WriteStartArray("__Array__");

            if (value is IEnumerable array)
            {
                foreach (var element in array)
                {
                    var eleType = element.GetType();
                    switch (Type.GetTypeCode(eleType))
                    {
                        case TypeCode.Byte:
                        case TypeCode.SByte:
                        case TypeCode.UInt16:
                        case TypeCode.UInt32:
                        case TypeCode.UInt64:
                        case TypeCode.Int16:
                        case TypeCode.Int32:
                        case TypeCode.Int64:
                            writer.WriteNumberValue(Convert.ToInt64(element));
                            break;
                        case TypeCode.Decimal:
                        case TypeCode.Double:
                        case TypeCode.Single:
                        case TypeCode.Empty:
                            break;
                        case TypeCode.Object:
                            writer.WriteStartObject();
                            WriteObject(writer, element, eleType, options);
                            writer.WriteEndObject();
                            break;
                        case TypeCode.DBNull:
                            break;
                        case TypeCode.Boolean:
                            break;
                        case TypeCode.Char:
                            break;
                        case TypeCode.DateTime:
                            break;
                        case TypeCode.String:
                            writer.WriteStringValue(element.ToString());
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            writer.WriteEndArray();
        }

        public static bool IsAutoProperty(PropertyInfo property)
        {
            var backingFieldName = $"<{property?.Name}>k__BackingField";
            var backingField =
                property?.DeclaringType?.GetField(backingFieldName, BindingFlags.NonPublic | BindingFlags.Instance);

            return backingField != null && backingField.GetCustomAttribute(typeof(CompilerGeneratedAttribute)) != null;
        }
    }
}
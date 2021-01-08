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
            var dict = ParseJsonToDictionary(ref reader, options);
            var obj = DictionaryToObject(dict, null);

            var resultType = typeof(T);
            var trackedResultType = typeof(TrackedResult<>);
            var constructedTrackedResult = trackedResultType.MakeGenericType(resultType.GetGenericArguments());
            var result = Activator.CreateInstance(constructedTrackedResult, obj);

            return (T) result;
        }

        public object DictionaryToObject(Dictionary<string, object> dictionary,
            Type[] propertyTypeGenericTypeArguments)
        {
            if (!dictionary.ContainsKey("__Type__")) return default;

            var type = dictionary["__Type__"];
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

            foreach (var (key, value) in dictionary)
            {
                switch (value)
                {
                    // Is nested object
                    case Dictionary<string, object> dict:
                    {
                        var propertyInfo = instanceType.GetProperty(key);
                        if (propertyInfo != null)
                        {
                            var obj = DictionaryToObject(dict, propertyInfo.PropertyType.GenericTypeArguments);
                            propertyInfo.SetValue(instance, obj);
                        }
                    }
                        break;

                    // Is nested array
                    case List<object> list:
                    {
                        var typeArgument = propertyTypeGenericTypeArguments[0];
                        AddEnumerableObject(list, (IList) instance, typeArgument);
                    }
                        break;

                    default:
                    {
                        var propertyInfo = instanceType.GetProperty(key);
                        if (propertyInfo != null && IsAutoProperty(propertyInfo))
                        {
                            propertyInfo.SetValue(instance, propertyInfo.PropertyType.IsEnum
                                ? Enum.ToObject(propertyInfo.PropertyType, (long) value)
                                : value);
                        }
                    }
                        break;
                }
            }

            return instance;
        }

        private void AddEnumerableObject(IEnumerable<object> list, IList instance, Type instanceType)
        {
            foreach (var obj in list)
            {
                switch (obj)
                {
                    case Dictionary<string, object> dict:
                    {
                        instance.Add(DictionaryToObject(dict, null));
                    }
                        break;

                    case long @enum when instanceType.IsEnum:
                    {
                        var value = Enum.ToObject(instanceType, @enum);
                        instance.Add(value);
                    }
                        break;

                    case long @long:
                    {
                        instance.Add(@long);
                    }
                        break;

                    default:
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
            }
        }

        public Dictionary<string, object> ParseJsonToDictionary(ref Utf8JsonReader reader,
            JsonSerializerOptions options)
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
                    return ParseJsonToDictionary(ref reader, options);
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
                WriteArray(writer, (IEnumerable) value, options);
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

            var properties =
                type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in properties)
            {
                writer.WritePropertyName(property.Name);
                if (property.PropertyType.IsInterface)
                {
                    if (IsEnumerable.IsAssignableFrom(property.PropertyType))
                    {
                        writer.WriteStartObject();
                        WriteArray(writer, (IEnumerable) property.GetValue(value), options);
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

        private void WriteArray(Utf8JsonWriter writer, IEnumerable enumerable, JsonSerializerOptions options)
        {
            if (enumerable == null)
                return;

            var type = enumerable.GetType();
            writer.WriteString("__Type__", type.AssemblyQualifiedName);
            writer.WriteStartArray("__Array__");

            foreach (var element in enumerable)
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

            writer.WriteEndArray();
        }

        /// <summary>
        /// Verifies that the property is assignable with a backing field.
        /// <br />Is: public string FullName { get; set; }
        /// <br />Is not: public string FullName => $"{FirstName} {LastName}";
        /// </summary>
        private static bool IsAutoProperty(PropertyInfo property)
        {
            var backingFieldName = $"<{property?.Name}>k__BackingField";
            var backingField =
                property?.DeclaringType?.GetField(backingFieldName, BindingFlags.NonPublic | BindingFlags.Instance);

            return backingField != null && backingField.GetCustomAttribute(typeof(CompilerGeneratedAttribute)) != null;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Library.Emit;

namespace Library.Communication.Converter
{
    public class InterfaceConverterImpl_v2<T> : JsonConverter<T>
    {
        private Type Enumerable { get; } = typeof(IEnumerable);
        private Dictionary<Type, Type> TypeCache { get; } = new Dictionary<Type, Type>();
        
        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var serializeType = Enumerable.IsInstanceOfType(value)
                ? typeof(IEnumerable<object>)
                : typeof(object);

            JsonSerializer.Serialize(writer, value, serializeType);
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dict = ParseJsonToDictionary(ref reader, options);
            var obj = DictionaryToObject2(dict, typeToConvert);

            return (T) obj;
        }

        private object DictionaryToObject2(IReadOnlyDictionary<string, object> dictionary, Type interfaceType)
        {
            object instance;
            if (Enumerable.IsAssignableFrom(interfaceType))
            {
                var arguments = interfaceType.GenericTypeArguments;
                if (arguments.Length > 1)
                    throw new Exception("Only handling of one generic array type allowed");

                var listType = typeof(List<>);
                var constructedListType = listType.MakeGenericType(arguments);
                instance = Activator.CreateInstance(constructedListType);
            }
            else
            {
                if (!TypeCache.TryGetValue(interfaceType, out var type))
                {
                    var classBuilder = new ClassBuilder();

                    classBuilder.AddInterface(interfaceType);
                    foreach (var @interface in interfaceType.GetInterfaces())
                    {
                        classBuilder.AddInterface(@interface);
                    }

                    type = classBuilder.CreateType();
                    TypeCache.Add(interfaceType, type);
                }

                instance = Activator.CreateInstance(type);
            }

            var instanceType = instance.GetType();

            foreach (var (key, value) in dictionary)
            {
                switch (value)
                {
                    // Is nested object
                    case Dictionary<string, object> dict:
                    {
                        var propertyInfo = GetPropertyIgnoreCase(instanceType, key);
                        if (propertyInfo != null)
                        {
                            var obj = DictionaryToObject2(dict, propertyInfo.PropertyType);
                            propertyInfo.SetValue(instance, obj);
                        }
                    }
                        break;

                    // Is nested array
                    case List<object> objects:
                    {
                        var propertyInfo = GetPropertyIgnoreCase(instanceType, key);
                        if (propertyInfo != null)
                        {
                            var arguments = propertyInfo.PropertyType.GenericTypeArguments;
                            if (arguments.Length > 1)
                                throw new Exception("Only handling of one generic array type allowed");

                            var listType = typeof(List<>);
                            var constructedListType = listType.MakeGenericType(arguments);
                            var list = Activator.CreateInstance(constructedListType);

                            var typeArgument = arguments[0];
                            AddEnumerableObject(objects, (IList) list, typeArgument);

                            propertyInfo.SetValue(instance, list);
                        }
                    }
                        break;

                    default:
                    {
                        var propertyInfo = GetPropertyIgnoreCase(instanceType, key);
                        if (propertyInfo != null)
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
                        instance.Add(DictionaryToObject2(dict, instanceType));
                    }
                        break;

                    default:
                    {
                        var value = instanceType.IsEnum
                            ? Enum.ToObject(instanceType, obj)
                            : obj;

                        instance.Add(value);
                    }
                        break;
                }
            }
        }

        private static PropertyInfo GetPropertyIgnoreCase(IReflect type, string key)
        {
            return type.GetProperty(key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        }

        private static Dictionary<string, object> ParseJsonToDictionary(ref Utf8JsonReader reader,
            JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException(
                    $"JsonTokenType was of type {reader.TokenType}, only objects are supported");
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

        private static object ExtractValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
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
    }
}
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
        private Type StringType { get; } = typeof(string);
        private Type IsEnumerable { get; } = typeof(IEnumerable);
        private Dictionary<Type, object> ImplementationCache { get; } = new Dictionary<Type, object>();
        private Dictionary<Type, Type> TypeCache { get; } = new Dictionary<Type, Type>();

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value);
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dict = ParseJsonToDictionary(ref reader, options);
            var obj = DictionaryToObject(dict, typeof(T));

            //var resultType = typeof(T);
            //var trackedResultType = typeof(TrackedResult<>);
            //var constructedTrackedResult = trackedResultType.MakeGenericType(resultType.GetGenericArguments());
            //var result = Activator.CreateInstance(constructedTrackedResult, obj);

            //return (T)result;

            return (T) obj;
        }

        private object DictionaryToObject(IReadOnlyDictionary<string, object> dictionary, Type interfaceType,
            ClassBuilder cBuilder = null)
        {
            var classBuilder = cBuilder == null
                ? new ClassBuilder()
                : new ClassBuilder(cBuilder);

            classBuilder.AddInterface(interfaceType);
            foreach (var @interface in interfaceType.GetInterfaces())
            {
                classBuilder.AddInterface(@interface);
            }

            foreach (var (key, value) in dictionary)
            {
                switch (value)
                {
                    // Is nested object
                    case Dictionary<string, object> dict:
                    {
                        var propertyInfo = GetPropertyIgnoreCase(interfaceType, key);
                        if (propertyInfo != null)
                        {
                            var obj = DictionaryToObject(dict, propertyInfo.PropertyType, classBuilder);
                            ImplementationCache.Add(propertyInfo.PropertyType, obj);
                        }
                    }
                        break;

                    // Is nested array
                    case List<object> list:
                    {
                        foreach (var ele in list)
                        {
                            switch (ele)
                            {
                                case Dictionary<string, object> innerDict:
                                {
                                    var propertyInfo = GetPropertyIgnoreCase(interfaceType, key);
                                    if (propertyInfo != null)
                                    {
                                        if (propertyInfo.PropertyType.GenericTypeArguments.Length > 1)
                                            throw new Exception("Only handling of one generic array type allowed");

                                        var concreteType = propertyInfo.PropertyType.GenericTypeArguments[0];
                                        if (!TypeCache.TryGetValue(concreteType, out _))
                                        {
                                            var obj = DictionaryToObject(innerDict, concreteType, classBuilder);
                                            TypeCache.Add(concreteType, obj.GetType());
                                        }
                                    }
                                }
                                    break;
                            }
                        }
                    }
                        break;
                }
            }

            Type classType = classBuilder.CreateType();
            object o = Activator.CreateInstance(classType);

            InjectValues(o, dictionary);

            void InjectValues(object instance, IReadOnlyDictionary<string, object> dict)
            {
                var instanceType = instance.GetType();
                foreach (var (key, value) in dict)
                {
                    if (value == null) continue;

                    var valueType = value.GetType();
                    if (valueType.IsPrimitive || valueType == StringType)
                    {
                        PropertyInfo pi = GetPropertyIgnoreCase(instanceType, key);
                        pi.SetValue(instance, pi.PropertyType.IsEnum
                            ? Enum.ToObject(pi.PropertyType, (long) value)
                            : value);
                    }
                    else if (IsEnumerable.IsAssignableFrom(valueType))
                    {
                        var pi = GetPropertyIgnoreCase(instanceType, key);
                        if (pi.PropertyType.GenericTypeArguments.Length > 1)
                            throw new Exception("Only handling of one generic array type allowed");

                        var listType = typeof(List<>);
                        var constructedListType = listType.MakeGenericType(pi.PropertyType.GenericTypeArguments);
                        var list = (IList) Activator.CreateInstance(constructedListType);

                        foreach (var ele in (IEnumerable) value)
                        {
                            switch (ele)
                            {
                                case Dictionary<string, object> innerDict:
                                {
                                    var obj = DictionaryToObject(innerDict, pi.PropertyType.GenericTypeArguments[0], classBuilder);
                                    list.Add(obj);
                                }
                                    break;
                                default:
                                {
                                    var type = pi.PropertyType.GenericTypeArguments[0];
                                    var concrete = type.IsEnum
                                        ? Enum.ToObject(type, ele)
                                        : ele;

                                    list.Add(concrete);
                                }
                                    break;
                            }
                        }

                        pi = GetPropertyIgnoreCase(instance.GetType(), key);
                        pi.SetValue(instance, list);
                    }
                    else
                    {
                        PropertyInfo pi = GetPropertyIgnoreCase(instance.GetType(), key);
                        if (ImplementationCache.TryGetValue(pi.PropertyType, out var impl))
                        {
                            pi.SetValue(instance, impl);
                        }
                    }
                }
            }

            return o;
        }

        private static PropertyInfo GetPropertyIgnoreCase(Type type, string key)
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
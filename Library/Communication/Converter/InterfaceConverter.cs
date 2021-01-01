using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Library.Communication.Converter
{
    public class InterfaceConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsInterface;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            JsonConverter converter = (JsonConverter) Activator.CreateInstance(
                typeof(InterfaceConverterImpl<>).MakeGenericType(typeToConvert),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: null,
                culture: null);

            return converter;
        }
    }
}
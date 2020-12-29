using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Interfaces.Model;
using Library.Converter;

namespace Library
{
    public class RPCResponse : IRPCResponse
    {
        public static RPCResponse Empty { get; } = new RPCResponse {Streams = new List<Stream>()};

        public IEnumerable<Stream> Streams { get; set; }

        public async IAsyncEnumerable<T> GetResult<T>()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new InterfaceConverter());
            
            foreach (var stream in Streams)
            {
                var response = await JsonSerializer.DeserializeAsync<ITrackedResult<T>>(stream, options);
                yield return response.__Object__;
            }
        }
    }
}
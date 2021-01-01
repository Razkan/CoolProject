using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Interfaces.Model;
using Library.Communication.Converter;

namespace Library.Communication
{
    public class RPCResponse : IRPCResponse
    {
        private static readonly JsonSerializerOptions _jsonSerializerOptions;
        
        static RPCResponse()
        {
            _jsonSerializerOptions = new JsonSerializerOptions();
            _jsonSerializerOptions.Converters.Add(new InterfaceConverter());
        }

        public List<Task<Stream>> Tasks { get; set; }
        public static RPCResponse Empty { get; } = new RPCResponse {Tasks = new List<Task<Stream>>()};

        public async IAsyncEnumerable<T> GetResult<T>()
        {
            var results = Tasks.Select(task => task.ContinueWith(async stream =>
            {
                var response = await JsonSerializer.DeserializeAsync<ITrackedObject<T>>(await stream, _jsonSerializerOptions);
                return response.__Object__;
            }).Unwrap());

            foreach (var result in results)
            {
                yield return await result;
            }
        }
    }
}
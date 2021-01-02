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
        public static RPCResponse Empty { get; } = new RPCResponse {Tasks = new List<Task<Stream>>()};

        private static readonly JsonSerializerOptions _jsonSerializerOptions;

        static RPCResponse()
        {
            _jsonSerializerOptions = new JsonSerializerOptions();
            _jsonSerializerOptions.Converters.Add(new InterfaceConverter());
        }

        public List<Task<Stream>> Tasks { get; set; }

        public async IAsyncEnumerable<T> GetResult<T>()
        {
            var enumerableTasks = Tasks.Select(task => task.ContinueWith(
                async stream =>
                {
                    var response =await JsonSerializer.DeserializeAsync<ITrackedResult<T>>(await stream, _jsonSerializerOptions);
                    return response.Get();
                }).Unwrap());

            foreach (var enumerableTask in enumerableTasks)
            {
                var enumerable = await enumerableTask;
                foreach (var result in enumerable)
                {
                    yield return result;
                }
            }
        }
    }
}
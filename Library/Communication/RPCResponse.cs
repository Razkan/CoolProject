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
            _jsonSerializerOptions.Converters.Add(new InterfaceConverter_v2());
        }

        public List<Task<Stream>> Tasks { get; set; }

        public async IAsyncEnumerable<T> GetResult<T>()
        {
            var enumerableTasks = Tasks.Select(task => task.ContinueWith(
                async stream =>
                {
                    var response2 = await JsonSerializer.DeserializeAsync<ITrackedArray<T>>(await stream, _jsonSerializerOptions);
                    return response2.__Array__;
                    //var response = await JsonSerializer.DeserializeAsync<ITrackedResult<T>>(await stream, _jsonSerializerOptions);
                    //return response.Get();
                    //return new TrackedResult<T>((ITrackedObject<T>)null).Get();
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

        public async IAsyncEnumerable<Stream> GetStreams()
        {
            foreach (var streamTask in Tasks)
            {
                yield return await streamTask;
            }
        }
    }
}
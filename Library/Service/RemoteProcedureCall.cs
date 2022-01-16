using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Interfaces.Model.Shared;
using Library.Communication;
using Library.Model;

namespace Library.Service
{
    public class RemoteProcedureCall : IRemoteProcedureCall
    {
        private const string ApplicationJsonMediaType = "application/json";
        private readonly IHttpClientFactory _httpClientFactory;

        public RemoteProcedureCall(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient GetClient()
        {
            return _httpClientFactory.CreateClient("client");
        }

        public async Task Register<TInterface>(Uri uri)
        {
            var interfaces = GetInterfaces(typeof(TInterface), new HashSet<string>());

            foreach (var @interface in interfaces)
            {
                var json = JsonSerializer.Serialize(new TrackEndpoint
                {
                    TInterface = @interface,
                    Uri = uri
                });

                var content = new StringContent(json, Encoding.UTF8, ApplicationJsonMediaType);

                var client = GetClient();
                var tracker_host = Environment.GetEnvironmentVariable("TRACKER_HOST") ?? "localhost:5000";
                await client.PostAsync($"http://{tracker_host}/tracker/post", content);
            }

            static ISet<string> GetInterfaces(Type type, ISet<string> set)
            {
                if (type == null || type.FullName == null)
                {
                    return set;
                }

                foreach (var interfaceType in type.GetInterfaces())
                {
                    GetInterfaces(interfaceType, set);
                }

                set.Add(type.FullName);
                return set;
            }
        }

        public async Task<IRPCResponse> GetAsync<TInterface>()
        {
            var client = GetClient();

            var trackerInfo = JsonSerializer.Serialize(new EndpointInfo
            {
                Type = typeof(TInterface).FullName
            });

            var content = new StringContent(trackerInfo, Encoding.UTF8, ApplicationJsonMediaType);

            var tracker_host = Environment.GetEnvironmentVariable("TRACKER_HOST") ?? "localhost:5000";
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri($"http://{tracker_host}/tracker/get"),
                Content = content,
                Method = HttpMethod.Get
            };

            var httpResponse = await client.SendAsync(request);

            if (!httpResponse.IsSuccessStatusCode)
            {
                return RPCResponse.Empty;
            }

            var fetch = JsonSerializer.Deserialize<Endpoint>(await httpResponse.Content.ReadAsStringAsync());
            if (fetch.URIs == null || !fetch.URIs.Any()) return RPCResponse.Empty;

            var streamTasks = new List<Task<Stream>>();

            foreach (var uri in fetch.URIs)
            {
                var streamTask = Task.Run(async () =>
                {
                    var response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var res =  await response.Content.ReadAsStreamAsync();
                        return res;
                    }

                    return Stream.Null;
                });

                streamTasks.Add(streamTask);
            }

            return new RPCResponse
            {
                Tasks = streamTasks
            };
        }
    }
}
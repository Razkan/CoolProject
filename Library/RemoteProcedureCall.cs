using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Library.Model;

namespace Library
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
                var json = JsonSerializer.Serialize(new Store
                {
                    TInterface = @interface,
                    Uri = uri
                });

                var content = new StringContent(json, Encoding.UTF8, ApplicationJsonMediaType);

                var client = GetClient();
                await client.PostAsync("http://localhost:5000/tracker/store", content);
            }

            static ISet<string> GetInterfaces(Type type, ISet<string> set)
            {
                if (type == null || type.FullName == null)
                {
                    return set;
                }

                foreach (var t in type.GetInterfaces())
                {
                    GetInterfaces(t, set);
                }

                set.Add(type.FullName);
                return set;
            }
        }

        public async Task<IRPCResponse> GetAsync<TInterface>()
        {
            var client = GetClient();

            var trackerInfo = JsonSerializer.Serialize(new TrackerInfo
            {
                Type = typeof(TInterface).FullName
            });

            var content = new StringContent(trackerInfo, Encoding.UTF8, ApplicationJsonMediaType);

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:5000/tracker/info"),
                Content = content,
                Method = HttpMethod.Get
            };

            var httpResponse = await client.SendAsync(request);

            if (!httpResponse.IsSuccessStatusCode)
            {
                return RPCResponse.Empty;
            }

            var fetch = JsonSerializer.Deserialize<Fetch>(await httpResponse.Content.ReadAsStringAsync());
            if (fetch.URIs == null || !fetch.URIs.Any()) return RPCResponse.Empty;

            var rpcStreams = new List<Stream>();
            foreach (var uri in fetch.URIs)
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var contentStream = await response.Content.ReadAsStreamAsync();
                    rpcStreams.Add(contentStream);
                }
            }

            return new RPCResponse
            {
                Streams = rpcStreams
            };
        }
    }
}
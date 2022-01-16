using System;
using System.Collections.Generic;
using Interfaces.Model.Shared;
using Library.Model;

namespace Library.Service
{
    public class Cache : ICache
    {
        private IDictionary<string, ISet<Uri>> _Dictionary { get; } = new Dictionary<string, ISet<Uri>>();

        public void Store(string @interface, Uri uri)
        {
            lock (_Dictionary)
            {
                if (!_Dictionary.TryGetValue(@interface, out var uriList))
                {
                    uriList = new HashSet<Uri> {uri};
                    _Dictionary.TryAdd(@interface, uriList);
                }

                uriList.Add(uri);
            }
        }

        public IEndpoint Get(string @interface)
        {
            return _Dictionary.TryGetValue(@interface, out var uriList)
                ? new Endpoint {URIs = uriList}
                : Endpoint.Empty;
        }
    }
}
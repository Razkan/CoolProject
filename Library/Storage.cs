using System;
using System.Collections.Generic;
using Interfaces.Model;
using Library.Model;

namespace Library
{
    public class Storage : IStorage
    {
        private IDictionary<string, ISet<Uri>> _storage { get; } = new Dictionary<string, ISet<Uri>>();

        public void Store(string @interface, Uri uri)
        {
            lock (_storage)
            {
                if (!_storage.TryGetValue(@interface, out var uriList))
                {
                    uriList = new HashSet<Uri> {uri};
                    _storage.TryAdd(@interface, uriList);
                }

                uriList.Add(uri);
            }
        }

        public IFetch Get(string @interface)
        {
            return _storage.TryGetValue(@interface, out var uriList)
                ? new Fetch {URIs = uriList}
                : Fetch.Empty;
        }
    }
}
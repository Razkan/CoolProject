using System.Collections.Generic;
using System.IO;

namespace Interfaces.Model.Shared
{
    public interface IRPCResponse
    {
        IAsyncEnumerable<T> GetResult<T>();
        IAsyncEnumerable<Stream> GetStreams();
    }
}
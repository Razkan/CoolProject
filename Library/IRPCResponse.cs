using System.Collections.Generic;

namespace Library
{
    public interface IRPCResponse
    {
        IAsyncEnumerable<T> GetResult<T>();
    }
}
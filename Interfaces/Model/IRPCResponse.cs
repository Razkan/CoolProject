using System.Collections.Generic;

namespace Interfaces.Model
{
    public interface IRPCResponse
    {
        IAsyncEnumerable<T> GetResult<T>();
    }
}
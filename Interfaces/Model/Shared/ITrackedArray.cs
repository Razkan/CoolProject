using System.Collections.Generic;

namespace Interfaces.Model.Shared
{
    public interface ITrackedArray<out T> 
    {
        string __Type__ { get; }
        IEnumerable<T> __Array__ { get; }
    }
}
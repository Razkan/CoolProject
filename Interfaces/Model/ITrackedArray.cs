using System.Collections.Generic;

namespace Interfaces.Model
{
    public interface ITrackedArray<T> 
    {
        string __Type__ { get; }
        IEnumerable<T> __Array__ { get; set; }
    }
}
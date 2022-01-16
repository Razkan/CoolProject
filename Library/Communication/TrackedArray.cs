using System.Collections.Generic;
using Interfaces.Model.Shared;

namespace Library.Communication
{
    public class TrackedArray<T> : ITrackedArray<T>

    {
        public TrackedArray()
        {
            __Type__ = GetType().AssemblyQualifiedName;
        }

        public TrackedArray(IEnumerable<T> arr) : this()
        {
            __Array__ = arr;
        }

        public string __Type__ { get; set; }
        public IEnumerable<T> __Array__ { get; set; }
    }
}
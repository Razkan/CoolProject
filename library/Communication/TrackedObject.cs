using Interfaces.Model;

namespace Library.Communication
{
    public class TrackedObject<T> : ITrackedObject<T>
    {
        public TrackedObject()
        {
            __Type__ = GetType().AssemblyQualifiedName;
        }

        public TrackedObject(T obj) : this()
        {
            __Object__ = obj;
        }

        public string __Type__ { get; set; }
        public T __Object__ { get; set; }
    }
}
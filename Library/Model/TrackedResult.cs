using Interfaces.Model;

namespace Library.Model
{
    public class TrackedResult<T> : ITrackedResult<T>
    {
        public TrackedResult()
        {
            __Type__ = GetType().AssemblyQualifiedName;
        }
        public string __Type__ { get; set; }
        public T __Object__ { get; set; }
    }
}
using System.Collections.Generic;

namespace Interfaces.Model
{
    public interface ITrackedResult<out T>
    {
        IEnumerable<T> Get();
    }
}
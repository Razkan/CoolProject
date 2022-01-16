using System.Collections.Generic;

namespace Interfaces.Model.Shared
{
    public interface ITrackedResult<out T>
    {
        IEnumerable<T> Get();
    }
}
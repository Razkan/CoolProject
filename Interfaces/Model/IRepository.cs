using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Model
{
    public interface IRepository
    {
        Task<T> GetAsync<T>(string id);
        Task<IEnumerable<T>> GetAllAsync<T>();
    }
}
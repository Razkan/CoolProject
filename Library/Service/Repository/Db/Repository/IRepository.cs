using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Service.Repository.Db.Repository
{
    // TODO change sealed database class to repositories, can add specific queries within each
    public interface IRepository<T>
    {
        Task<T> SelectAsync(string id);
        
        Task<IEnumerable<T>> SelectAllAsync();

        Task<bool> ContainsAsync(string id);

        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<ulong> CountAsync();
    }
}
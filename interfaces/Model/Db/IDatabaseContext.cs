using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Model.Db
{
    public interface IDatabaseContext : IDisposable
    {
        Task RunAsync();
        
        Task<T> SelectAsync<T>(string id);
        
        Task<IEnumerable<T>> SelectAllAsync<T>();

        Task<bool> ContainsAsync<T>(string id);
        
        Task InsertAsync<T>(T entity);

        Task UpdateAsync<T>(T entity);

        Task DeleteAsync<T>(T entity);

        Task<ulong> CountAsync<T>();
    }
}
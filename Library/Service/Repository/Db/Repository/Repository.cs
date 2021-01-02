using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces.Model.Db;

namespace Library.Service.Repository.Db.Repository
{
    public class Repository<T> : IRepository<T>
    {
        protected IDatabaseContext Context { get; }

        protected Repository(IDatabaseContext context)
        {
            Context = context;
        }

        public async Task<T> SelectAsync(string id) => await Context.SelectAsync<T>(id);

        public async Task<IEnumerable<T>> SelectAllAsync() => await Context.SelectAllAsync<T>();

        public async Task<bool> ContainsAsync(string id) => await Context.ContainsAsync<T>(id);

        public async Task InsertAsync(T entity) => await Context.InsertAsync(entity);

        public async Task UpdateAsync(T entity) => await Context.UpdateAsync(entity);

        public async Task DeleteAsync(T entity) => await Context.DeleteAsync(entity);

        public async Task<ulong> CountAsync() => await Context.CountAsync<T>();
    }
}
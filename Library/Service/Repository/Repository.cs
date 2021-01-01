using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces.Model;
using Interfaces.Model.Db;
using Library.Service.Repository.Db.Repository;

namespace Library.Service.Repository
{
    public class Repository : IRepository
    {
        private readonly IDatabase _database;

        public Repository(IDatabase database)
        {
            _database = database;
        }

        public async Task<T> GetAsync<T>(string id)
        {
            var repository = GetRepository<T>();
            return await repository.SelectAsync(id);
        }

        public Task<IEnumerable<T>> GetAllAsync<T>()
        {
            throw new System.NotImplementedException();
        }

        private IRepository<T> GetRepository<T>()
        {
            var repository = new GenericRepository<T>(_database);
            return repository;
        }
    }
}
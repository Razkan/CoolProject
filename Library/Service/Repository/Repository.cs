using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces.Model;
using Interfaces.Model.Db;
using Library.Service.Repository.Db.Repository;

namespace Library.Service.Repository
{
    public class Repository : IRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public Repository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<T> GetAsync<T>(string id)
        {
            var repository = GetRepository<T>();
            return await repository.SelectAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var repository = GetRepository<T>();
            return await repository.SelectAllAsync();
        }

        private IRepository<T> GetRepository<T>()
        {
            var repository = new GenericRepository<T>(_databaseContext);
            return repository;
        }
    }
}
using Interfaces.Model.Db;

namespace Library.Service.Repository.Db.Repository
{
    public class GenericRepository<T> : Repository<T>, IRepository<T>
    {
        public GenericRepository(IDatabase context) : base(context)
        {
        }
    }
}
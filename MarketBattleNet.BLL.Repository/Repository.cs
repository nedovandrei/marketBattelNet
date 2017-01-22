using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MarketBattleNet.DAL.RepositoryInterface;

namespace MarketBattleNet.BLL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _db;
        protected readonly DbSet<T> ObjectSet;

        public Repository(DbContext db)
        {
            _db = db;
            ObjectSet = db.Set<T>();
        }

        public void Create(T data)
        {
            _db.Set<T>().Add(data);
        }

        public void Update(T entity)
        {
            _db.Set<T>().Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T data)
        {
            _db.Entry(data).State = EntityState.Deleted;
        }

        public IQueryable<T> GetAll()
        {            
            return _db.Set<T>();
        }

        public void AddRange(IEnumerable<T> data)
        {
            _db.Set<T>().AddRange(data);            
        }

    }
}

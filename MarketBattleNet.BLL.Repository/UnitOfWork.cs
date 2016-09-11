using MarketBattleNet.DAL.DbContext;
using MarketBattleNet.DAL.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketBattleNet.BLL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext Context;
        //private DbContextTransaction _transaction;

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }
        public IRepository<T> Repository<T>() where T : class
        {
            var repositoryType = typeof(Repository<>);

            return (IRepository<T>)Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), Context);
        }
        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
        public void Dispose()
        {
            //_transaction?. Dispose();
            // Dispose();
            Context.Dispose();
        }
    }
}

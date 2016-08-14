using System;

namespace MarketBattleNet.DAL.RepositoryInterface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        int SaveChanges();
    }
}

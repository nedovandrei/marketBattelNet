using System.Linq;

namespace MarketBattleNet.DAL.RepositoryInterface
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        void Create(T data);
        void Update(T data);
        void Delete(T data);

    }
}

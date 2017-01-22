using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MarketBattleNet.DAL.DbContext;
using MarketBattleNet.DAL.Models;
using MarketBattleNet.DAL.RepositoryInterface;

namespace MarketBattleNet.BLL.Repository
{
    public class CustomRequestRepository : ICustomRequestRepository
    {
        private readonly DbContext _db;

        public CustomRequestRepository(DbContext db)
        {
            _db = db;
        }

        public IQueryable<RequestModel> GetAll()
        {
            return _db.Set<RequestModel>().Include(x => x.ArtModel).Include(x => x.UserProfileModel);
        }
    }
}

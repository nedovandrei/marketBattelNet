using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketBattleNet.DAL.Models;

namespace MarketBattleNet.DAL.RepositoryInterface
{
    public interface ICustomRequestRepository
    {
        IQueryable<RequestModel> GetAll();
    }
}

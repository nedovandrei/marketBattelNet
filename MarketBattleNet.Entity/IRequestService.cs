using MarketBattleNet.BLL.ServiceInterface.DTO;
using System.Collections.Generic;

namespace MarketBattleNet.BLL.ServiceInterface
{
    public interface IRequestService
    {
        IEnumerable<RequestDTO> GetAll();
        RequestDTO FindById(int id);
        void Add(RequestDTO obj);
        void Update(RequestDTO obj);
        void Delete(int id);
    }
}

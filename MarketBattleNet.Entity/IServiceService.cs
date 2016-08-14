using MarketBattleNet.BLL.ServiceInterface.DTO;
using System.Collections.Generic;

namespace MarketBattleNet.BLL.ServiceInterface
{
    public interface IServiceService
    {
        IEnumerable<ServiceDTO> GetAll();
        ServiceDTO FindById(int id);
        void Add(ServiceDTO obj);
        void Update(ServiceDTO obj);
        void Delete(int id);

    }
}

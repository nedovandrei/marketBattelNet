using MarketBattleNet.BLL.ServiceInterface.DTO;
using System.Collections.Generic;

namespace MarketBattleNet.BLL.ServiceInterface
{
    public interface IArtService
    {
        IEnumerable<ArtDTO> GetAll();
        ArtDTO FindById(int id);
        void Add(ArtDTO obj);
        void Update(ArtDTO obj);
        void Delete(int id);
    }
}

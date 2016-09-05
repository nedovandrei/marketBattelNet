using MarketBattleNet.BLL.ServiceInterface.DTO;
using System.Collections.Generic;

namespace MarketBattleNet.BLL.ServiceInterface
{
    public interface IGameService
    {
        IEnumerable<GameDTO> GetAll();
        GameDTO FindById(int id);
        void Add(GameDTO obj);
        void Update(GameDTO obj);
        void Delete(int id);

    }
}

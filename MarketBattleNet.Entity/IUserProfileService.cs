using MarketBattleNet.BLL.ServiceInterface.DTO;
using System.Collections.Generic;

namespace MarketBattleNet.BLL.ServiceInterface
{
    public interface IUserProfileService
    {
        IEnumerable<UserProfileDTO> GetAll();
        UserProfileDTO FindById(int id);
        void Add(UserProfileDTO obj);
        void Update(UserProfileDTO obj);
        void Delete(int id);
    }
}

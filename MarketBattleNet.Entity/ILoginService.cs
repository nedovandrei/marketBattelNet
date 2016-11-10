using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketBattleNet.BLL.ServiceInterface.DTO;

namespace MarketBattleNet.BLL.ServiceInterface
{
    public interface ILoginService
    {
        bool LoginCheck(string userName, string password);
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MarketBattleNet.BLL.ServiceInterface;
using MarketBattleNet.BLL.ServiceInterface.DTO;

namespace MarketBattleNet.BLL.Service
{
    public class LoginService : ILoginService
    {
        public bool LoginCheck(string userName, string password)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(password));
            var passwordHashBytes = new SHA1Cng().ComputeHash(stream);
            var passwordHash = Convert.ToBase64String(passwordHashBytes);

            var correctUser = new LoginDTO();
            if (userName == correctUser.UserName && passwordHash == correctUser.PasswordHash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MarketBattleNet.BLL.ServiceInterface;
using MarketBattleNet.PL.API.Models;

namespace MarketBattleNet.PL.API.Controllers
{
    public class LoginController : ApiController
    {

        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public HttpResponseMessage Login(LoginViewModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            return _loginService.LoginCheck(model.UserName, model.Password)
                ? Request.CreateResponse(HttpStatusCode.OK, true)
                : Request.CreateErrorResponse(HttpStatusCode.Forbidden, "Wrong Data");
        }
    }
}

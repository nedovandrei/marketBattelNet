using MarketBattleNet.BLL.ServiceInterface;
using MarketBattleNet.BLL.ServiceInterface.DTO;
using MarketBattleNet.PL.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MarketBattleNet.PL.API.Controllers
{
    public class UserProfileController : ApiController
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var data = _userProfileService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        public HttpResponseMessage FindById(int id)
        {
            if(id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "UserProfileController > FindById(); : Id came in null");
            }

            var data = _userProfileService.FindById(id);
            if(data == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"UserProfileController > FindById(); : Nothing found by the id: {id}");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        public HttpResponseMessage Add(UserProfileViewModel model)
        {
            if(model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "UserProfileController > Add(); : Model Came in null");
            }
            var modelDTO = new UserProfileDTO()
            {
                FullName = model.FullName,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber
            };
            _userProfileService.Add(modelDTO);
            var data = _userProfileService.FindByPhoneNumber(model.PhoneNumber);
            return Request.CreateResponse(HttpStatusCode.Created, data);
        }

        [HttpPut]
        public HttpResponseMessage Update(UserProfileViewModel model)
        {
            if(model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "UserProfileController > Update(); : Model Came in null");
            }
            var modelDTO = new UserProfileDTO()
            {
                Id = model.Id,
                FullName = model.FullName,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber
            };
            _userProfileService.Update(modelDTO);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            if(id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "UserProfileController > Delete(); : ID came in null");
            }
            _userProfileService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

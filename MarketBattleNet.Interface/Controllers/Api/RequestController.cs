using MarketBattleNet.BLL.ServiceInterface;
using MarketBattleNet.BLL.ServiceInterface.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MarketBattleNet.Interface.Models;

namespace MarketBattleNet.Interface.Controllers.Api
{
    public class RequestController : ApiController
    {
        private readonly IRequestService _requestService;
        private readonly IArtService _artService;
        private readonly IUserProfileService _userProfileService;

        public RequestController(IRequestService requestService, IArtService artService, IUserProfileService userProfileService)
        {
            _requestService = requestService;
            _artService = artService;
            _userProfileService = userProfileService;
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var data = _requestService.GetAll();

            
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        public HttpResponseMessage FindById(int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Request Controller > FindById(); : No ID was specified");
            }

            var data = _requestService.FindById(id);
            if(data == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Request Controller > FindById(); : Not Found Anything With This Id: {id}");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        public HttpResponseMessage Add(RequestViewModel model)
        {
            var modelDTO = new RequestDTO()
            {
                ArtId = model.ArtId,
                UserId = model.UserId,
                Colour = model.Colour,
                TShirtSex = model.TShirtSex,
                TShirtSize = model.TShirtSize,
                IsCompleted = model.IsCompleted
            };
            _requestService.Add(modelDTO);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage Update(RequestViewModel model)
        {
            var modelDTO = new RequestDTO()
            {
                Id = model.Id,
                UserId = model.UserId,
                ArtId = model.ArtId,
                Colour = model.Colour,
                TShirtSex = model.TShirtSex,
                TShirtSize = model.TShirtSize,
                IsCompleted = model.IsCompleted
            };
            _requestService.Update(modelDTO);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            _requestService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("api/request/AddRange")]
        public HttpResponseMessage AddRange(IEnumerable<RequestViewModel> modelList)
        {
            var dtoList = modelList.Select(item => new RequestDTO()
            {
                UserId = item.UserId,
                ArtId = item.ArtId,
                Colour = item.Colour,
                TShirtSex = item.TShirtSex,
                TShirtSize = item.TShirtSize,
                IsCompleted = item.IsCompleted
            }).ToList();

            _requestService.AddRange(dtoList);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPost]
        [Route("api/request/CompleteRequest/{id}")]
        public HttpResponseMessage CompleteRequest(int id)
        {
            var data = _requestService.FindById(id);

            data.IsCompleted = true;

            _requestService.Update(data);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

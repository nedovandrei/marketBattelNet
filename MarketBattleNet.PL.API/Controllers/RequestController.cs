using MarketBattleNet.BLL.ServiceInterface;
using MarketBattleNet.BLL.ServiceInterface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MarketBattleNet.PL.API.Controllers
{
    public class RequestController : ApiController
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
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
            var data = _requestService.FindById(id);
            if(data == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Not Found Anything With This Id: {id}");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        public HttpResponseMessage Add(RequestViewModel model)
        {
            var modelDTO = new RequestDTO()
            {
                //object copy logic
            };
            _requestService.Add(modelDTO);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}

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
    public class ArtController : ApiController
    {
        private readonly IArtService _artService;
        public ArtController(IArtService artService)
        {
            _artService = artService;
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var data = _artService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        public HttpResponseMessage FindById(int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ArtController > FindById(); : No Id was specified");
            }

            var data = _artService.FindById(id);
            if (data == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"ArtController > FindById(); : Not Found Anything With This Id: {id}");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        public HttpResponseMessage Add(ArtViewModel model)
        {
            if (model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ArtController > Add(); : Model came null");
            }
            var modelDTO = new ArtDTO()
            {
                GameId = model.GameId,
                Name = model.Name,
                Description = model.Description,
                ThumbnailFileName = model.ThumbnailFileName,
                LargeFileName = model.LargeFileName
            };
            _artService.Add(modelDTO);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage Update(ArtViewModel model)
        {
            if (model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ArtController > Update(); : Model came null");
            }

            var modelDTO = new ArtDTO()
            {
                Id = model.Id,
                Name = model.Name,
                GameId = model.GameId,
                Description = model.Description,
                ThumbnailFileName = model.ThumbnailFileName,
                LargeFileName = model.LargeFileName
            };
            _artService.Update(modelDTO);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ArtController > Delete(); : No ID specified");
            }

            _artService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/art/findByGameId/{id}")]
        public HttpResponseMessage FindByGameId(int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "ArtController > FindByGameId(); : No ID specified");
            }

           var data = _artService.GetAll().Where(x => x.GameId == id);

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}

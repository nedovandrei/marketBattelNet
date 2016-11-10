using System;
using System.Collections.Generic;
using MarketBattleNet.BLL.ServiceInterface;
using MarketBattleNet.BLL.ServiceInterface.DTO;
using MarketBattleNet.PL.API.Models;
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
                Type = model.Type,
                NameRus = model.NameRus,
                NameEng = model.NameEng,
                NameRom = model.NameRom,
                DescriptionRus = model.DescriptionRus,
                DescriptionEng = model.DescriptionEng,
                DescriptionRom = model.DescriptionRom,
                Price = model.Price,
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
                Type = model.Type,
                NameRus = model.NameRus,
                NameEng = model.NameEng,
                NameRom = model.NameRom,
                GameId = model.GameId,
                DescriptionRus = model.DescriptionRus,
                DescriptionEng = model.DescriptionEng,
                DescriptionRom = model.DescriptionRom,
                Price = model.Price,
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

        [HttpGet]
        [Route("api/art/getCountByGameId/{id}")]
        public HttpResponseMessage GetCountByGameId(int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    "ArtController > GetCountByGameId(); : No ID specified");
            }
            var data = _artService.GetAll().Count();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        

        [HttpGet]
        [Route("api/art/search")]
        public HttpResponseMessage Search(string searchString)
        {
            const StringComparison comp = StringComparison.OrdinalIgnoreCase;

            var data = _artService.GetAll().Where(x =>
                x.NameRom.Contains(searchString, comp) ||
                x.NameEng.Contains(searchString, comp) ||
                x.NameRus.Contains(searchString, comp) ||
                x.DescriptionEng.Contains(searchString, comp) ||
                x.DescriptionRom.Contains(searchString, comp) ||
                x.DescriptionRus.Contains(searchString, comp)).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }

    public static class StringExtensions
    {
        public static bool Contains(this String str, String substring,
                                    StringComparison comp)
        {
            if (substring == null)
                throw new ArgumentNullException("substring",
                                                "substring cannot be null.");
            else if (!Enum.IsDefined(typeof(StringComparison), comp))
                throw new ArgumentException("comp is not a member of StringComparison",
                                            "comp");

            return str.IndexOf(substring, comp) >= 0;
        }
    }
}

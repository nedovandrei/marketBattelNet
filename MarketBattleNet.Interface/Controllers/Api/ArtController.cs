using System;
using System.Collections.Generic;
using MarketBattleNet.BLL.ServiceInterface;
using MarketBattleNet.BLL.ServiceInterface.DTO;
using MarketBattleNet.Interface.Models;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MarketBattleNet.Interface.Controllers.Api
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

        [HttpPost]
        [Route("api/art/getAllExt")]
        public HttpResponseMessage GetSorted(ParamsModel parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));

            var data = _artService.GetAll();

            if (parameters.GameId != null)
            {
                data = data.Where(x => x.GameId == parameters.GameId);
            }
            if (parameters.ByType?.Count > 0)
            {
                var tempList = new List<ArtDTO>();
                foreach (var type in parameters.ByType)
                {
                    tempList.AddRange(data.Where(x => x.Type == type));
                }
                data = tempList;
            }
            if (parameters.ByDate != null)
            {
                data = parameters.ByDate == "asc" ? data.OrderBy(x => x.DateCreated) : data.OrderByDescending(x => x.DateCreated);
            }
            else if (parameters.ByPrice != null)
            {
                data = parameters.ByPrice == "asc" ? data.OrderBy(x => x.Price) : data.OrderByDescending(x => x.Price);
            }
            if (parameters.SearchString != null)
            {
                const StringComparison comp = StringComparison.OrdinalIgnoreCase;
                data = data.Where(x =>
                x.NameRom.Contains(parameters.SearchString, comp) ||
                x.NameEng.Contains(parameters.SearchString, comp) ||
                x.NameRus.Contains(parameters.SearchString, comp) ||
                x.DescriptionEng.Contains(parameters.SearchString, comp) ||
                x.DescriptionRom.Contains(parameters.SearchString, comp) ||
                x.DescriptionRus.Contains(parameters.SearchString, comp));
            }
            

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
                LargeFileName = model.LargeFileName,
                LargeFileName2 = model.LargeFileName2,
                LargeFileName3 = model.LargeFileName3,
                LargeFileName4 = model.LargeFileName4
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
                LargeFileName = model.LargeFileName,
                LargeFileName2 = model.LargeFileName2,
                LargeFileName3 = model.LargeFileName3,
                LargeFileName4 = model.LargeFileName4
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

using MarketBattleNet.BLL.ServiceInterface;
using MarketBattleNet.BLL.ServiceInterface.DTO;
using MarketBattleNet.PL.API.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MarketBattleNet.PL.API.Controllers
{
    public class GameController : ApiController
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var data = _gameService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        public HttpResponseMessage FindById(int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"GameController > FindById(); : No id specified");
            }

            var data = _gameService.FindById(id);
            if (data == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"GameController > FindById(); : No data was found with this ID: {id}");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        public HttpResponseMessage Add(GameViewModel model)
        {
            if (model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "GameController > Add(); : Model came null");
            }
            var modelDTO = new GameDTO()
            {
                Name = model.Name,
                BackgroundFileName = model.BackgroundFileName,
                LogoFileName = model.LogoFileName
                
            };
            _gameService.Add(modelDTO);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage Update(GameViewModel model)
        {
            if (model == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "GameController > Update(); : Model came null");
            }
            var modelDTO = new GameDTO()
            {
                Id = model.Id,
                Name = model.Name,
                BackgroundFileName = model.BackgroundFileName,
                LogoFileName = model.LogoFileName
            };
            _gameService.Update(modelDTO);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            if(id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "GameController > Update(); : Id came null");
            }
            _gameService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}

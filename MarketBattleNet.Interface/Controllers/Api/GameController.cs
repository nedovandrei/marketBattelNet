using System.Collections.Generic;
using System.Linq;
using MarketBattleNet.BLL.ServiceInterface;
using MarketBattleNet.BLL.ServiceInterface.DTO;
using MarketBattleNet.Interface.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MarketBattleNet.Interface.Controllers.Api
{
    public class GameController : ApiController
    {
        private readonly IGameService _gameService;
        private readonly IArtService _artService;

        public GameController(IGameService gameService, IArtService artService)
        {
            _gameService = gameService;
            _artService = artService;
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var gameData = _gameService.GetAll();
            var dataToSend = new List<GameViewModel>();
            foreach (var game in gameData)
            {
                var artData = _artService.GetAll().Count(x => x.GameId == game.Id);
                dataToSend.Add(new GameViewModel()
                {
                    Id = game.Id,
                    NameRus = game.NameRus,
                    NameEng = game.NameEng,
                    NameRom = game.NameEng,
                    LogoFileName = game.LogoFileName,
                    BackgroundFileName = game.BackgroundFileName,
                    ArtCount = artData
                });

            }
            return Request.CreateResponse(HttpStatusCode.OK, dataToSend);
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
                NameRus = model.NameRus,
                NameEng = model.NameEng,
                NameRom = model.NameRom,
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
                NameRus = model.NameRus,
                NameEng = model.NameEng,
                NameRom = model.NameRom,
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

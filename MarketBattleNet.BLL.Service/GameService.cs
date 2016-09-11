﻿using MarketBattleNet.BLL.ServiceInterface;
using MarketBattleNet.BLL.ServiceInterface.DTO;
using MarketBattleNet.DAL.Models;
using MarketBattleNet.DAL.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace MarketBattleNet.BLL.Service
{
    public class GameService : IGameService
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<GameModel> _repository;

        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Repository<GameModel>();
        }

        public IEnumerable<GameDTO> GetAll()
        {
            var data = _repository.GetAll();
            var dtoToSend = new List<GameDTO>();
            foreach (var request in data)
            {
                dtoToSend.Add(new GameDTO()
                {
                    Id = request.Id,
                    Name = request.Name
                });
            }
            return dtoToSend;
        }

        public GameDTO FindById(int id)
        {
            var data = _repository.GetAll().FirstOrDefault(x => x.Id == id);
            var dtoToSend = new GameDTO()
            {
                Id = data.Id,
                Name = data.Name
            };
            return dtoToSend;
        }

        public void Add(GameDTO obj)
        {
            var data = new GameModel()
            {
                Id = obj.Id,
                Name = obj.Name
            };
            _repository.Create(data);
        }

        public void Update(GameDTO obj)
        {
            var data = new GameModel()
            {
                Id = obj.Id,
                Name = obj.Name
            };
            _repository.Update(data);
        }

        public void Delete(int id)
        {
            var dataToDelete = FindById(id);
            var data = new GameModel()
            {
                Id = dataToDelete.Id,
                Name = dataToDelete.Name
            };
            _repository.Delete(data);
        }
    }
}
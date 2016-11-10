using MarketBattleNet.DAL.RepositoryInterface;
using MarketBattleNet.BLL.ServiceInterface;
using System.Collections.Generic;
using MarketBattleNet.DAL.Models;
using MarketBattleNet.BLL.ServiceInterface.DTO;
using System.Linq;

namespace MarketBattleNet.BLL.Service
{
    public class RequestService : IRequestService
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<RequestModel> _repository;

        public RequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<RequestModel>();
        }

        public IEnumerable<RequestDTO> GetAll()
        {
            var data = _repository.GetAll();
            var dtoToSend = new List<RequestDTO>();
            foreach(var request in data)
            {
                dtoToSend.Add(new RequestDTO()
                                    {
                                        Id = request.Id,
                                        UserId = request.UserId,
                                        ArtId = request.ArtId
                                    });
            }
            return dtoToSend;
        }

        public RequestDTO FindById(int id)
        {
            var data = _repository.GetAll().FirstOrDefault(x => x.Id == id);
            var dtoToSend = new RequestDTO()
            {
                Id = data.Id,
                UserId = data.UserId,
                ArtId = data.ArtId
            };
            return dtoToSend;
        }

        public void Add(RequestDTO obj)
        {
            var data = new RequestModel()
            {
                Id = obj.Id,
                UserId = obj.UserId,
                ArtId = obj.ArtId
            };
            _repository.Create(data);
            _unitOfWork.SaveChanges();
        }

        public void Update(RequestDTO obj)
        {
            var data = new RequestModel()
            {
                Id = obj.Id,
                UserId = obj.UserId,
                ArtId = obj.ArtId
            };
            _repository.Update(data);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            var dataToDelete = FindById(id);
            var data = new RequestModel()
            {
                Id = dataToDelete.Id,
                UserId = dataToDelete.UserId,                
                ArtId = dataToDelete.ArtId
            };
            _repository.Delete(data);
            _unitOfWork.SaveChanges();
        }

        public void AddRange(IEnumerable<RequestDTO> data)
        {
            var modelList = data.Select(item => new RequestModel()
            {
                UserId = item.UserId, ArtId = item.ArtId
            }).ToList();
            _repository.AddRange(modelList);
            _unitOfWork.SaveChanges();
        }
    }
}

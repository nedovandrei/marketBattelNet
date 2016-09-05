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
            _repository = unitOfWork.Repository<RequestModel>();
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
                UserId = data.Id,
                ArtId = data.ArtId
            };
            return dtoToSend;
        }

        public void Add(RequestDTO obj)
        {
            var data = new RequestModel()
            {
                Id = obj.Id,
                UserId = obj.Id,
                ArtId = obj.ArtId
            };
            _repository.Create(data);
        }

        public void Update(RequestDTO obj)
        {
            var data = new RequestModel()
            {
                Id = obj.Id,
                UserId = obj.Id,
                ArtId = obj.ArtId
            };
            _repository.Update(data);
        }

        public void Delete(int id)
        {
            var dataToDelete = FindById(id);
            var data = new RequestModel()
            {
                Id = dataToDelete.Id,
                UserId = dataToDelete.Id,                
                ArtId = dataToDelete.ArtId
            };
            _repository.Delete(data);
        }
    }
}

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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<RequestModel> _repository;
        private readonly ICustomRequestRepository _customRequestRepository;

        public RequestService(IUnitOfWork unitOfWork, ICustomRequestRepository customRequestRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<RequestModel>();
            _customRequestRepository = customRequestRepository;
        }

        public IEnumerable<RequestDTO> GetAll()
        {
            var data = _customRequestRepository.GetAll();
            var dtoToSend = new List<RequestDTO>();
            foreach(var request in data)
            {
                dtoToSend.Add(new RequestDTO()
                                    {
                                        Id = request.Id,
                                        UserId = request.UserProfileModelId,
                                        ArtId = request.ArtModelId,
                                        Colour = request.Colour,
                                        TShirtSize = request.TShirtSize,
                                        TShirtSex = request.TShirtSex,
                                        UserProfileModel = request.UserProfileModel,
                                        ArtModel = request.ArtModel,
                                        IsCompleted = request.IsCompleted
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
                UserId = data.UserProfileModelId,
                ArtId = data.ArtModelId,
                Colour = data.Colour,
                TShirtSize = data.TShirtSize,
                TShirtSex = data.TShirtSex,
                UserProfileModel = data.UserProfileModel,
                ArtModel = data.ArtModel,
                IsCompleted = data.IsCompleted
            };
            return dtoToSend;
        }

        public void Add(RequestDTO obj)
        {
            var data = new RequestModel()
            {
                Id = obj.Id,
                UserProfileModelId = obj.UserId,
                ArtModelId = obj.ArtId,
                Colour = obj.Colour,
                TShirtSize = obj.TShirtSize,
                TShirtSex = obj.TShirtSex,
                IsCompleted = obj.IsCompleted
            };
            _repository.Create(data);
            _unitOfWork.SaveChanges();
        }

        public void Update(RequestDTO obj)
        {
            //var data = new RequestModel()
            //{
            //    Id = obj.Id,
            //    UserProfileModelId = obj.UserId,
            //    ArtModelId = obj.ArtId,
            //    Colour = obj.Colour,
            //    TShirtSize = obj.TShirtSize,
            //    TShirtSex = obj.TShirtSex
            //};

            var data = _repository.GetAll().FirstOrDefault(x => x.Id == obj.Id);

            data.ArtModelId = obj.ArtId;
            data.UserProfileModelId = obj.UserId;
            data.Colour = obj.Colour;
            data.TShirtSize = obj.TShirtSize;
            data.TShirtSex = obj.TShirtSex;
            data.IsCompleted = obj.IsCompleted;

            _repository.Update(data);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            var dataToDelete = _repository.GetAll().FirstOrDefault(x => x.Id == id);            
            _repository.Delete(dataToDelete);
            _unitOfWork.SaveChanges();
        }

        public void AddRange(IEnumerable<RequestDTO> data)
        {
            var modelList = data.Select(item => new RequestModel()
            {
                UserProfileModelId = item.UserId,
                ArtModelId = item.ArtId,
                Colour = item.Colour,
                TShirtSize = item.TShirtSize,
                TShirtSex = item.TShirtSex,
                IsCompleted = item.IsCompleted
            }).ToList();
            _repository.AddRange(modelList);
            _unitOfWork.SaveChanges();
        }
    }
}

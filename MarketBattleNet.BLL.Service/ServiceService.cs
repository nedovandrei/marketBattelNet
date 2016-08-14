using MarketBattleNet.BLL.ServiceInterface.DTO;
using MarketBattleNet.DAL.Models;
using MarketBattleNet.DAL.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace MarketBattleNet.BLL.Service
{
    public class ServiceService
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<ServiceModel> _repository;

        public ServiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Repository<ServiceModel>();
        }

        public IEnumerable<ServiceDTO> GetAll()
        {
            var data = _repository.GetAll();
            var dtoToSend = new List<ServiceDTO>();
            foreach (var request in data)
            {
                dtoToSend.Add(new ServiceDTO()
                {
                    Id = request.Id,
                    Name = request.Name
                });
            }
            return dtoToSend;
        }

        public ServiceDTO FindById(int id)
        {
            var data = _repository.GetAll().FirstOrDefault(x => x.Id == id);
            var dtoToSend = new ServiceDTO()
            {
                Id = data.Id,
                Name = data.Name
            };
            return dtoToSend;
        }

        public void Add(ServiceDTO obj)
        {
            var data = new ServiceModel()
            {
                Id = obj.Id,
                Name = obj.Name
            };
            _repository.Create(data);
        }

        public void Update(ServiceDTO obj)
        {
            var data = new ServiceModel()
            {
                Id = obj.Id,
                Name = obj.Name
            };
            _repository.Update(data);
        }

        public void Delete(int id)
        {
            var dataToDelete = FindById(id);
            var data = new ServiceModel()
            {
                Id = dataToDelete.Id,
                Name = dataToDelete.Name
            };
            _repository.Delete(data);
        }
    }
}

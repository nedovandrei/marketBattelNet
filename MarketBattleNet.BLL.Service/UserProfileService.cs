using MarketBattleNet.BLL.ServiceInterface;
using MarketBattleNet.BLL.ServiceInterface.DTO;
using MarketBattleNet.DAL.Models;
using MarketBattleNet.DAL.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace MarketBattleNet.BLL.Service
{
    public class UserProfileService : IUserProfileService
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<UserProfileModel> _repository;

        public UserProfileService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<UserProfileModel>();
        }

        public IEnumerable<UserProfileDTO> GetAll()
        {
            var data = _repository.GetAll();
            var dtoToSend = new List<UserProfileDTO>();
            foreach (var userProfile in data)
            {
                dtoToSend.Add(new UserProfileDTO()
                {
                    Id = userProfile.Id,
                    FullName = userProfile.FullName,
                    Address = userProfile.Address,
                    PhoneNumber = userProfile.PhoneNumber,
                    City = userProfile.City              
                });
            }
            return dtoToSend;
        }

        public UserProfileDTO FindById(int id)
        {
            var data = _repository.GetAll().FirstOrDefault(x => x.Id == id);
            var dtoToSend = new UserProfileDTO()
            {
                Id = data.Id,
                FullName = data.FullName,
                Address = data.Address,
                PhoneNumber = data.PhoneNumber,
                City = data.City
            };
            return dtoToSend;
        }

        public UserProfileDTO FindByPhoneNumber(string phoneNumber)
        {
            var data = _repository.GetAll().FirstOrDefault(x => x.PhoneNumber == phoneNumber);
            var dtoToSend = new UserProfileDTO()
            {
                Id = data.Id,
                FullName = data.FullName,
                Address = data.Address,
                PhoneNumber = data.PhoneNumber,
                City = data.City
            };
            return dtoToSend;
        }

        public void Add(UserProfileDTO obj)
        {
            var data = new UserProfileModel()
            {
                Id = obj.Id,
                FullName = obj.FullName,
                Address = obj.Address,
                PhoneNumber = obj.PhoneNumber,
                City = obj.City
            };
            _repository.Create(data);
            _unitOfWork.SaveChanges();
        }

        public void Update(UserProfileDTO obj)
        {
            var data = new UserProfileModel()
            {
                Id = obj.Id,
                FullName = obj.FullName,
                Address = obj.Address,
                PhoneNumber = obj.PhoneNumber,
                City = obj.City
            };
            _repository.Update(data);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            var dataToDelete = FindById(id);
            var data = new UserProfileModel()
            {
                Id = dataToDelete.Id,
                FullName = dataToDelete.FullName,
                Address = dataToDelete.Address,
                PhoneNumber = dataToDelete.PhoneNumber,
                City = dataToDelete.City
            };
            _repository.Delete(data);
            _unitOfWork.SaveChanges();
        }
    }
}

using MarketBattleNet.BLL.ServiceInterface.DTO;
using MarketBattleNet.DAL.Models;
using MarketBattleNet.DAL.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace MarketBattleNet.BLL.Service
{
    public class ArtService
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<ArtModel> _repository;

        public ArtService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.Repository<ArtModel>();
        }

        public IEnumerable<ArtDTO> GetAll()
        {
            var data = _repository.GetAll();
            var dtoToSend = new List<ArtDTO>();
            foreach (var request in data)
            {
                dtoToSend.Add(new ArtDTO()
                {
                    Id = request.Id,
                    Description = request.Description,
                    GameName = request.GameName,
                    FileName = request.FileName
                });
            }
            return dtoToSend;
        }

        public ArtDTO FindById(int id)
        {
            var data = _repository.GetAll().FirstOrDefault(x => x.Id == id);
            var dtoToSend = new ArtDTO()
            {
                Id = data.Id,
                Description = data.Description,
                GameName = data.GameName,
                FileName = data.FileName
            };
            return dtoToSend;
        }

        public void Add(ArtDTO obj)
        {
            var data = new ArtModel()
            {
                Id = obj.Id,
                Description = obj.Description,
                GameName = obj.GameName,
                FileName = obj.FileName
            };
            _repository.Create(data);
        }

        public void Update(ArtDTO obj)
        {
            var data = new ArtModel()
            {
                Id = obj.Id,
                Description = obj.Description,
                GameName = obj.GameName,
                FileName = obj.FileName
            };
            _repository.Update(data);
        }

        public void Delete(int id)
        {
            var dataToDelete = FindById(id);
            var data = new ArtModel()
            {
                Id = dataToDelete.Id,
                Description = dataToDelete.Description,
                GameName = dataToDelete.GameName,
                FileName = dataToDelete.FileName
            };
            _repository.Delete(data);
        }
    }
}

using MarketBattleNet.BLL.ServiceInterface;
using MarketBattleNet.BLL.ServiceInterface.DTO;
using MarketBattleNet.DAL.Models;
using MarketBattleNet.DAL.RepositoryInterface;
using System.Collections.Generic;
using System.Linq;

namespace MarketBattleNet.BLL.Service
{
    public class ArtService : IArtService
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<ArtModel> _repository;

        public ArtService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository<ArtModel>();
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
                    Name = request.Name,
                    Description = request.Description,
                    GameId = request.GameId,
                    ThumbnailFileName = request.ThumbnailFileName,
                    LargeFileName = request.LargeFileName
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
                Name = data.Name,
                Description = data.Description,
                GameId = data.GameId,
                ThumbnailFileName = data.ThumbnailFileName,
                LargeFileName = data.LargeFileName
            };
            return dtoToSend;
        }

        public void Add(ArtDTO obj)
        {
            var data = new ArtModel()
            {
                Id = obj.Id,
                Name = obj.Name,
                Description = obj.Description,
                GameId = obj.GameId,
                ThumbnailFileName = obj.ThumbnailFileName,
                LargeFileName = obj.LargeFileName
            };
            _repository.Create(data);
        }

        public void Update(ArtDTO obj)
        {
            var data = new ArtModel()
            {
                Id = obj.Id,
                Name = obj.Name,
                Description = obj.Description,
                GameId = obj.GameId,
                ThumbnailFileName = obj.ThumbnailFileName,
                LargeFileName = obj.LargeFileName
            };
            _repository.Update(data);
        }

        public void Delete(int id)
        {
            var dataToDelete = FindById(id);
            var data = new ArtModel()
            {
                Id = dataToDelete.Id,
                Name = dataToDelete.Name,
                Description = dataToDelete.Description,
                GameId = dataToDelete.GameId,
                ThumbnailFileName = dataToDelete.ThumbnailFileName,
                LargeFileName = dataToDelete.LargeFileName
            };
            _repository.Delete(data);
        }
    }
}

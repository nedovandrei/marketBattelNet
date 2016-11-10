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
                    Type = request.Type,
                    NameRus = request.NameRus,
                    NameEng = request.NameEng,
                    NameRom = request.NameRom,
                    DescriptionRus = request.DescriptionRus,
                    DescriptionEng = request.DescriptionEng,
                    DescriptionRom = request.DescriptionRom,
                    Price = request.Price,
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
                Type = data.Type,
                NameRus = data.NameRus,
                NameEng = data.NameEng,
                NameRom = data.NameRom,
                DescriptionRus = data.DescriptionRus,
                DescriptionEng = data.DescriptionEng,
                DescriptionRom = data.DescriptionRom,
                Price = data.Price,
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
                NameRus = obj.NameRus,
                NameEng = obj.NameEng,
                NameRom = obj.NameRom,
                Type = obj.Type,
                DescriptionRus = obj.DescriptionRus,
                DescriptionEng = obj.DescriptionEng,
                DescriptionRom = obj.DescriptionRom,
                Price = obj.Price,
                GameId = obj.GameId,
                ThumbnailFileName = obj.ThumbnailFileName,
                LargeFileName = obj.LargeFileName
            };
            _repository.Create(data);
            _unitOfWork.SaveChanges();
        }

        public void Update(ArtDTO obj)
        {
            var data = new ArtModel()
            {
                Id = obj.Id,
                Type = obj.Type,
                NameRus = obj.NameRus,
                NameEng = obj.NameEng,
                NameRom = obj.NameRom,
                DescriptionEng = obj.DescriptionEng,
                DescriptionRus = obj.DescriptionRus,
                DescriptionRom = obj.DescriptionRom,
                Price = obj.Price,
                GameId = obj.GameId,
                ThumbnailFileName = obj.ThumbnailFileName,
                LargeFileName = obj.LargeFileName
            };
            _repository.Update(data);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            var dataToDelete = FindById(id);
            var data = new ArtModel()
            {
                Id = dataToDelete.Id,
                Type = dataToDelete.Type,
                NameRus = dataToDelete.NameRus,
                NameEng = dataToDelete.NameEng,
                NameRom = dataToDelete.NameRom,
                DescriptionRus = dataToDelete.DescriptionRus,
                DescriptionEng = dataToDelete.DescriptionEng,
                DescriptionRom = dataToDelete.DescriptionRom,
                Price = dataToDelete.Price,
                GameId = dataToDelete.GameId,
                ThumbnailFileName = dataToDelete.ThumbnailFileName,
                LargeFileName = dataToDelete.LargeFileName
            };
            _repository.Delete(data);
            _unitOfWork.SaveChanges();
        }
    }
}

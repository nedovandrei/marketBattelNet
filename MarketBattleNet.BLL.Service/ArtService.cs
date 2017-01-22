using System;
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
                    LargeFileName = request.LargeFileName,
                    LargeFileName2 = request.LargeFileName2,
                    LargeFileName3 = request.LargeFileName3,
                    LargeFileName4 = request.LargeFileName4,
                    DateCreated = request.DateCreated
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
                LargeFileName = data.LargeFileName,
                LargeFileName2 = data.LargeFileName2,
                LargeFileName3 = data.LargeFileName3,
                LargeFileName4 = data.LargeFileName4,
                DateCreated = data.DateCreated
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
                LargeFileName = obj.LargeFileName,
                LargeFileName2 = obj.LargeFileName2,
                LargeFileName3 = obj.LargeFileName3,
                LargeFileName4 = obj.LargeFileName4,
                DateCreated = DateTime.Now
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
                LargeFileName = obj.LargeFileName,
                LargeFileName2 = obj.LargeFileName2,
                LargeFileName3 = obj.LargeFileName3,
                LargeFileName4 = obj.LargeFileName4,
                DateCreated = obj.DateCreated
            };
            _repository.Update(data);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            var dataToDelete = _repository.GetAll().FirstOrDefault(x => x.Id == id);            
            _repository.Delete(dataToDelete);
            _unitOfWork.SaveChanges();
        }
    }
}

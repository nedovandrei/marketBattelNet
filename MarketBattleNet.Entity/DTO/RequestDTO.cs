using MarketBattleNet.DAL.Models;

namespace MarketBattleNet.BLL.ServiceInterface.DTO
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserProfileModel UserProfileModel { get; set; }
        public string Colour { get; set; }
        public string TShirtSize { get; set; }
        public string TShirtSex { get; set; }
        public int ArtId { get; set; }
        public ArtModel ArtModel { get; set; }
        public bool IsCompleted { get; set; }
    }
}

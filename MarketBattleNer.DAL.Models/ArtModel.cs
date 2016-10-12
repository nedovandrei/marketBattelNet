namespace MarketBattleNet.DAL.Models
{
    public class ArtModel
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumbnailFileName { get; set; }
        public string LargeFileName { get; set; }
    }
}

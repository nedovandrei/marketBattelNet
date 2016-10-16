namespace MarketBattleNet.DAL.Models
{
    public class ArtModel
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Type { get; set; }
        public string NameRus { get; set; }
        public string NameEng { get; set; }
        public string NameRom { get; set; }
        public string DescriptionRus { get; set; }
        public string DescriptionEng { get; set; }
        public string DescriptionRom { get; set; }
        public string ThumbnailFileName { get; set; }
        public string LargeFileName { get; set; }
    }
}

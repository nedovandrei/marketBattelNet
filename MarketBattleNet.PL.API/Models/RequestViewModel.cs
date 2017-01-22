namespace MarketBattleNet.PL.API.Controllers
{
    public class RequestViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ArtId { get; set; }
        public string Colour { get; set; }
        public string TShirtSize { get; set; }
        public string TShirtSex { get; set; }
        public bool IsCompleted { get; set; }
    }
}
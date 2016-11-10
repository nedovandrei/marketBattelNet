namespace MarketBattleNet.DAL.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ArtId { get; set; }
        public bool IsCompleted { get; set; }
    }
}

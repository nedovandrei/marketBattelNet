using System.ComponentModel.DataAnnotations;

namespace MarketBattleNet.DAL.Models
{
    public class GameModel
    {
        [Key]
        public int Id { get; set; }        
        public string Name { get; set; }        
        public string LogoFileName { get; set; }
        public string BackgroundFileName { get; set; }
    }
}

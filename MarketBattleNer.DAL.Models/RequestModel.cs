using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace MarketBattleNet.DAL.Models
{
    public class RequestModel
    {
        [Key]
        public int Id { get; set; }

        public int UserProfileModelId { get; set; }

        [ForeignKey("UserProfileModelId")]
        public UserProfileModel UserProfileModel { get; set; }   
             
        public int ArtModelId { get; set; }

        [ForeignKey("ArtModelId")]
        public ArtModel ArtModel { get; set; }
        public string Colour { get; set; }
        public string TShirtSize { get; set; }
        public string TShirtSex { get; set; }

        public bool IsCompleted { get; set; }
    }
}

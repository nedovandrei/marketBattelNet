using System.ComponentModel.DataAnnotations;

namespace MarketBattleNet.DAL.Models
{
    public class UserProfileModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }

    }
}

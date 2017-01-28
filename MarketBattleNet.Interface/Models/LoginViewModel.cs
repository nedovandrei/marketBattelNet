using System.ComponentModel.DataAnnotations;

namespace MarketBattleNet.Interface.Models
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
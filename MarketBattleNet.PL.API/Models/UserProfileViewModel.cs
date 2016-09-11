using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketBattleNet.PL.API.Models
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
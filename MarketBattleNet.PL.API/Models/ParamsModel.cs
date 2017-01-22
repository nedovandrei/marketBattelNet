using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketBattleNet.PL.API.Models
{
    public class ParamsModel
    {
        public string ByPrice { get; set; }
        public string ByDate { get; set; }
        public List<string> ByType { get; set; }
        public int? GameId { get; set; }
        public string SearchString { get; set; }
    }
}
using System.Collections.Generic;

namespace MarketBattleNet.Interface.Models
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
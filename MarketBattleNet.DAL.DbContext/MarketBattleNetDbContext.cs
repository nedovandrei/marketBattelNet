using MarketBattleNet.DAL.Models;
using System.Data.Entity;

namespace MarketBattleNet.DAL.DbContext
{
    public class MarketBattleNetDbContext : System.Data.Entity.DbContext
    {
        public MarketBattleNetDbContext() : base("MarketBattleNetDataBase")
        {
        }

        public DbSet<RequestModel> Requests { get; set; }
        public DbSet<UserProfileModel> UserProfiles { get; set; }
        public DbSet<GameModel> Games { get; set; }
        public DbSet<ArtModel> Arts { get; set; }
    }
}

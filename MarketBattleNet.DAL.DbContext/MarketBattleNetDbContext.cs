using MarketBattleNet.DAL.Models;
using System.Data.Entity;

namespace MarketBattleNet.DAL.DbContext
{
    public class MarketBattleNerDbContext : System.Data.Entity.DbContext
    {
        public MarketBattleNerDbContext() : base("MarketBattleNetDataBase") { }

        public DbSet<RequestModel> Requests { get; set; }
        public DbSet<UserProfileModel> UserProfiles { get; set; }
        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<ArtModel> Arts { get; set; }
    }
}

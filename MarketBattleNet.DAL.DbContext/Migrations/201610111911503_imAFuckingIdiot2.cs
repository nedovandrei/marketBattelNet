namespace MarketBattleNet.DAL.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imAFuckingIdiot2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ArtModels", "GameId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ArtModels", "GameId", c => c.String());
        }
    }
}

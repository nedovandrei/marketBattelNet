namespace MarketBattleNet.DAL.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceForArtModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArtModels", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArtModels", "Price");
        }
    }
}

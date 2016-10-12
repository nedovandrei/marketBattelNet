namespace MarketBattleNet.DAL.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArtNameField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArtModels", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArtModels", "Name");
        }
    }
}

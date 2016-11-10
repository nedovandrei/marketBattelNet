namespace MarketBattleNet.DAL.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimeToArtAndIsCompletedToRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArtModels", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.RequestModels", "IsCompleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RequestModels", "IsCompleted");
            DropColumn("dbo.ArtModels", "DateCreated");
        }
    }
}

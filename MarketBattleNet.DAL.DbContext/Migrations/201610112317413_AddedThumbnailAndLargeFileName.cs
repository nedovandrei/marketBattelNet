namespace MarketBattleNet.DAL.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedThumbnailAndLargeFileName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArtModels", "ThumbnailFileName", c => c.String());
            AddColumn("dbo.ArtModels", "LargeFileName", c => c.String());
            DropColumn("dbo.ArtModels", "FileName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ArtModels", "FileName", c => c.String());
            DropColumn("dbo.ArtModels", "LargeFileName");
            DropColumn("dbo.ArtModels", "ThumbnailFileName");
        }
    }
}

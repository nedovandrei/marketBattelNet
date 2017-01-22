namespace MarketBattleNet.DAL.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        Type = c.String(),
                        NameRus = c.String(),
                        NameEng = c.String(),
                        NameRom = c.String(),
                        DescriptionRus = c.String(),
                        DescriptionEng = c.String(),
                        DescriptionRom = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThumbnailFileName = c.String(),
                        LargeFileName = c.String(),
                        LargeFileName2 = c.String(),
                        LargeFileName3 = c.String(),
                        LargeFileName4 = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LogoFileName = c.String(),
                        BackgroundFileName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserProfileModelId = c.Int(nullable: false),
                        ArtModelId = c.Int(nullable: false),
                        Colour = c.String(),
                        TShirtSize = c.String(),
                        TShirtSex = c.String(),
                        IsCompleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArtModels", t => t.ArtModelId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfileModels", t => t.UserProfileModelId, cascadeDelete: true)
                .Index(t => t.UserProfileModelId)
                .Index(t => t.ArtModelId);
            
            CreateTable(
                "dbo.UserProfileModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestModels", "UserProfileModelId", "dbo.UserProfileModels");
            DropForeignKey("dbo.RequestModels", "ArtModelId", "dbo.ArtModels");
            DropIndex("dbo.RequestModels", new[] { "ArtModelId" });
            DropIndex("dbo.RequestModels", new[] { "UserProfileModelId" });
            DropTable("dbo.UserProfileModels");
            DropTable("dbo.RequestModels");
            DropTable("dbo.GameModels");
            DropTable("dbo.ArtModels");
        }
    }
}

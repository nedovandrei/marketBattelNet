namespace MarketBattleNet.DAL.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UserProfileModels");
            DropTable("dbo.RequestModels");
            DropTable("dbo.GameModels");
            DropTable("dbo.ArtModels");

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
                        ThumbnailFileName = c.String(),
                        LargeFileName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameRus = c.String(),
                        NameEng = c.String(),
                        NameRom = c.String(),
                        LogoFileName = c.String(),
                        BackgroundFileName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ArtId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfileModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserProfileModels");
            DropTable("dbo.RequestModels");
            DropTable("dbo.GameModels");
            DropTable("dbo.ArtModels");
        }
    }
}

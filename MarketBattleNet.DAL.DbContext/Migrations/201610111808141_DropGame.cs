namespace MarketBattleNet.DAL.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropGame : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.GameModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GameModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LogoFileName = c.Int(nullable: false),
                        BackgroundFileName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}

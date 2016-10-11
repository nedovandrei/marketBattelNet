namespace MarketBattleNet.DAL.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGameModel : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GameModels");
        }
    }
}

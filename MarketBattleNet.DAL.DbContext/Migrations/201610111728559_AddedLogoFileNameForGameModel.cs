namespace MarketBattleNet.DAL.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLogoFileNameForGameModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameModels", "LogoFileName", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameModels", "LogoFileName");
        }
    }
}

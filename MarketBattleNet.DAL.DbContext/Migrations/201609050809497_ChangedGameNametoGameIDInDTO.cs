namespace MarketBattleNet.DAL.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedGameNametoGameIDInDTO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameModels", "BackgroundFileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameModels", "BackgroundFileName");
        }
    }
}

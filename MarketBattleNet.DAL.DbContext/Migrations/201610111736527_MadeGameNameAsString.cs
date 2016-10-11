namespace MarketBattleNet.DAL.DbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeGameNameAsString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GameModels", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameModels", "Name", c => c.Int(nullable: false));
        }
    }
}

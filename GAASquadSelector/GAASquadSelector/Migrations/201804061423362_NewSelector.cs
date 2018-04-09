namespace GAASquadSelector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewSelector : DbMigration
    {
        public override void Up()
        {
            
        }

        public override void Down()
        {

            DropForeignKey("dbo.Selector", "PlayerID", "dbo.Player");
            DropForeignKey("dbo.Selector", "SquadID", "dbo.Squad");
            DropIndex("dbo.Selector", new[] { "PlayerID" });
            DropIndex("dbo.Selector", new[] { "SquadID" });
            DropTable("dbo.Selector");
            
        }
    }
}

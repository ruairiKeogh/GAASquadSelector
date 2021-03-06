namespace GAASquadSelector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropSelectors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Selector",
                c => new
                {
                    SelectionID = c.Int(nullable: false, identity: true),
                    SquadID = c.Int(nullable: false),
                    PlayerID = c.Int(nullable: false),
                    Position = c.String(nullable: false)
                })
                .PrimaryKey(t => t.SelectionID)
            .ForeignKey("dbo.Player", t => t.PlayerID, cascadeDelete: true)
            .ForeignKey("dbo.Squad", t => t.SquadID, cascadeDelete: true)
            .Index(t => t.PlayerID)
            .Index(t => t.SquadID); ;
        }
        
        public override void Down()
        {

            DropForeignKey("dbo.Selector", "PlayerID", "dbo.Player");
            DropForeignKey("dbo.Selector", "SquadID", "dbo.Squad");
            DropForeignKey("dbo.Selectors", "PlayerID", "dbo.Player");
            DropForeignKey("dbo.Selectors", "SquadID", "dbo.Squad");
            DropIndex("dbo.Selector", new[] { "PlayerID" });
            DropIndex("dbo.Selector", new[] { "SquadID" });
            DropIndex("dbo.Selectors", new[] { "PlayerID" });
            DropIndex("dbo.Selectors", new[] { "SquadID" });
            DropTable("dbo.Selector");
            DropTable("dbo.Selectors");
        }
    }
}

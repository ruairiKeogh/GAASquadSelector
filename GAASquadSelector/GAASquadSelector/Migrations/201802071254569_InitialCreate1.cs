namespace GAASquadSelector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
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
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SelectionID)
                .ForeignKey("dbo.Player", t => t.PlayerID, cascadeDelete: true)
                .ForeignKey("dbo.Squad", t => t.SquadID, cascadeDelete: true)
                .Index(t => t.SquadID)
                .Index(t => t.PlayerID);
            
            CreateTable(
                "dbo.Squad",
                c => new
                    {
                        SquadID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SquadID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Selector", "SquadID", "dbo.Squad");
            DropForeignKey("dbo.Selector", "PlayerID", "dbo.Player");
            DropIndex("dbo.Selector", new[] { "PlayerID" });
            DropIndex("dbo.Selector", new[] { "SquadID" });
            DropTable("dbo.Squad");
            DropTable("dbo.Selector");
        }
    }
}

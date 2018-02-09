namespace GAASquadSelector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Position = c.String(),
                        UserId = c.String()
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t=> t.UserId, cascadeDelete: true);

            CreateTable(
                "dbo.Squad",
                c => new
                {
                    SquadID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Date = c.DateTime()
                    })
                    .PrimaryKey(t => t.SquadID);

            CreateTable(
                "dbo.Selector",
                c => new
                {
                    SelectorID = c.Int(nullable: false),
                    SquadID = c.Int(nullable: false),
                    PlayerID = c.Int(nullable: false),
                    Position = c.String(nullable: false)
                })
                .PrimaryKey(t => t.SelectorID)
            .ForeignKey("dbo.Player", t => t.PlayerID, cascadeDelete: true)
            .ForeignKey("dbo.Squad", t => t.SquadID, cascadeDelete: true)
            .Index(t => t.PlayerID)
            .Index(t => t.SquadID); ;
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Selector", "PlayerID", "dbo.Player");
            DropForeignKey("dbo.Selector", "SquadID", "dbo.Squad");
            DropIndex("dbo.Selector", new[] { "PlayerID" });
            DropIndex("dbo.Selector", new[] { "SquadID" });
            DropTable("dbo.Squad");
            DropTable("dbo.Selector");
            DropTable("dbo.Player");
        }
    }
}

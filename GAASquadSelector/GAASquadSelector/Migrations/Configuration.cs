namespace GAASquadSelector.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GAASquadSelector.DAL.SquadContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "GAASquadSelector.DAL.SquadContext";
        }

        protected override void Seed(GAASquadSelector.DAL.SquadContext context)
        {
            
        }
    }
}

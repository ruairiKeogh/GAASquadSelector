using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GAASquadSelector.Models;

namespace GAASquadSelector.DAL
{
    public class PlayerInitializer : DropCreateDatabaseIfModelChanges<SquadContext>
    {
        protected override void Seed(SquadContext context)
        {
            var players = new List<Player>
            {
                new Player{ FirstName = "Ruairí", LastName = "Keogh", Position="Forward"}
            };

            players.ForEach(p => context.Players.Add(p));
            context.SaveChanges();

        }
    }
}
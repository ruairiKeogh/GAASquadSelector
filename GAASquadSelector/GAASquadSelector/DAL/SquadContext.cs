﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAASquadSelector.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GAASquadSelector.DAL
{
    public class SquadContext : DbContext
    {
        public SquadContext() : base("DefaultConnection")
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Selector> Selections { get; set; }
        public DbSet<Squad> Squads { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
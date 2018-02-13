﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAASquadSelector.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GAASquadSelector.DAL
{
    public class SquadContext : DbContext

    {
        public SquadContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SquadContext>());
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Selector> Selections { get; set; }
        public DbSet<Squad> Squads { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasRequired(p=>p.User).WithMany(p=>p.players).HasForeignKey(d=>d.UserID).WillCascadeOnDelete(false);

            //modelBuilder.Entity<Course>().HasRequired(t => t.Department).WithMany(t => t.Courses).HasForeignKey(d => d.DepartmentID).WillCascadeOnDelete(false);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RushHour.Models;
using System.Data.Entity;

namespace RushHour.DataAccess
{
    public class RushHourContext : DbContext
    {
        public RushHourContext() : base("RushHourDb") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            base.OnModelCreating(modelBuilder);
        }

    }
}
﻿namespace SharedTrip.Data
{
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Data.Models;

    public class SharedTripDbContext : DbContext
    {       
        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips{ get; set; }
        public DbSet<UserTrip> UserTrips{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>()
                .HasKey(x => new { x.TripId, x.UserId });
        }
    }
}

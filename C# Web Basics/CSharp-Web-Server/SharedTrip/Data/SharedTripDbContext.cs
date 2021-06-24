namespace SharedTrip.Data
{
    using Microsoft.EntityFrameworkCore;

    public class SharedTripDbContext : DbContext
    {
        public SharedTripDbContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips{ get; set; }
        public DbSet<UserTrip> UserTrips{ get; set; }

        public SharedTripDbContext(DbContextOptions db)
            : base(db)
        {
        }

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

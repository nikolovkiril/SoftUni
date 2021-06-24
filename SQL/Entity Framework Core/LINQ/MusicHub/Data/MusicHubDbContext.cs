namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Song>  Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Performer> Performers{ get; set; }
        public DbSet<Writer> Writers{ get; set; }
        public DbSet<SongPerformer> SongPerformers{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SongPerformer>(entity =>
            {
                entity.HasKey(sp => new { sp.SongId, sp.PerformerId });

                entity.HasOne(s => s.Performer)
                .WithMany(s => s.PerformerSongs)
                .HasForeignKey(s => s.PerformerId);

                entity.HasOne(s => s.Song)
                .WithMany(p => p.SongPerformers)
                .HasForeignKey(s => s.SongId);
            });

            builder.Entity<Song>(entity =>
            {
                entity.HasOne(p => p.Album)
                .WithMany(s => s.Songs)
                .HasForeignKey(s => s.AlbumId);

                entity.HasOne(s => s.Writer)
                .WithMany(w => w.Songs)
                .HasForeignKey(s => s.WriterId);

            });

            builder.Entity<Album>(entity =>
            {
                entity.HasOne(p => p.Producer)
                .WithMany(p => p.Albums)
                .HasForeignKey(p => p.ProducerId);
            });
        }
    }
}

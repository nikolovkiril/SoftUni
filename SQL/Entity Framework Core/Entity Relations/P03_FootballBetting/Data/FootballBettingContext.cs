﻿using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }
        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=Football;Integrated Security=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(pl =>
            {
                pl.HasKey(p => p.PlayerId);

                pl.HasOne(p => p.Team)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.TeamId);

                pl.HasOne(p => p.Position)
                .WithMany(p => p.Players)
                .HasForeignKey(p => p.PositionId);
            });

            modelBuilder.Entity<PlayerStatistic>(ps =>
            {
                ps.HasKey(x => new { x.PlayerId, x.GameId });

                ps
                    .HasOne(ps => ps.Game)
                    .WithMany(ps => ps.PlayerStatistics)
                    .HasForeignKey(ps => ps.GameId)
                    .OnDelete(DeleteBehavior.Restrict);

                ps
                    .HasOne(ps => ps.Player)
                    .WithMany(ps => ps.PlayerStatistics)
                    .HasForeignKey(ps => ps.PlayerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Team>(tm =>
            {
                tm.HasOne(t => t.PrimaryKitColor)
                .WithMany(t => t.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                tm.HasOne(t => t.SecondaryKitColor)
                 .WithMany(t => t.SecondaryKitTeams)
                 .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);


                tm.HasOne(t => t.Town)
                .WithMany(t => t.Teams)
                .HasForeignKey(t => t.TownId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Game>(game =>
            {
                game.HasKey(g => g.GameId);

                game.HasOne(g => g.HomeTeam)
                .WithMany(g => g.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);


                game.HasOne(x => x.AwayTeam)
                .WithMany(x => x.AwayGames)
                .HasForeignKey(x => x.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Bet>(bet =>
            {
                bet.HasKey(b => b.BetId);

                bet.HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

                bet.HasOne(b => b.Game)
                    .WithMany(g => g.Bets)
                    .HasForeignKey(b => b.GameId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Color>(color =>
            {
                color.HasKey(c => c.ColorId);

                color.Property(c => c.Name)
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(30);
            });

            modelBuilder.Entity<Town>(tw =>
            {
                tw.HasOne(t => t.Country)
                .WithMany(t => t.Towns)
                .HasForeignKey(t => t.CountryId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

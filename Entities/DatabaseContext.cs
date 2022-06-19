using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zadaniedodatkowe.Entities.Models;

namespace zadaniedodatkowe.Entities
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<GameCompany> GameCompanies { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Game>(e =>
            {
                e.ToTable("Game");
                e.HasKey(e => e.IdGame);

                e.Property(e => e.Name).HasMaxLength(100).IsRequired();
                e.Property(e => e.Description).HasMaxLength(100).IsRequired();

                e.HasData(
                    new Game
                    {
                        IdGame = 1,
                        Name = "Wiedzmin 3",
                        ReleaseDate = new System.DateTime(2015, 6, 5),
                        Description = "fajna gra"
                    }
                );
            });

            modelBuilder.Entity<Company>(e =>
            {
                e.ToTable("Company");
                e.HasKey(e => e.IdCompany);

                e.Property(e => e.Name).HasMaxLength(100).IsRequired();
                e.Property(e => e.Location).HasMaxLength(100).IsRequired();
                e.Property(e => e.CreationDate).IsRequired();

                e.HasData(
                    new Company
                    {
                        IdCompany = 1,
                        Name = "CD Projekt RED",
                        Location = "Warszawa",
                        CreationDate = new System.DateTime(2002, 6, 5)
                    },
                    new Company
                    {
                        IdCompany = 2,
                        Name = "FromSoftware",
                        Location = "Japonia",
                        CreationDate = new System.DateTime(2004, 6, 5)
                    }
                );
            });

            modelBuilder.Entity<GameCompany>(e =>
            {
                e.ToTable("GameCompany");
                e.HasKey(e => new {e.IdGame, e.IdCompany});
                e.HasOne(e => e.Game).WithMany(e => e.GameCompanies).HasForeignKey(e => e.IdGame).OnDelete(DeleteBehavior.ClientCascade);
                e.HasOne(e => e.Company).WithMany(e => e.GameCompanies).HasForeignKey(e => e.IdCompany).OnDelete(DeleteBehavior.ClientCascade);

                e.HasData(
                    new GameCompany
                    {
                        IdGame = 1,
                        IdCompany = 1
                    }
                );
            });
        }
    }
}
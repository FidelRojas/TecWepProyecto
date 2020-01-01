using PremierLeague.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PremierLeague.Data
{
    public class PremierLeagueDbContext : DbContext
    {
        public PremierLeagueDbContext(DbContextOptions<PremierLeagueDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EquipoEntity>().ToTable("Equipos");
            modelBuilder.Entity<EquipoEntity>().HasMany(a => a.Jugadores).WithOne(b => b.Equipo);
            modelBuilder.Entity<EquipoEntity>().Property(a => a.id).ValueGeneratedOnAdd();

            modelBuilder.Entity<JugadorEntity>().ToTable("Jugadores");
            modelBuilder.Entity<JugadorEntity>().Property(b => b.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<JugadorEntity>().HasOne(b => b.Equipo).WithMany(a => a.Jugadores);
        }

        public DbSet<EquipoEntity> Equipos { get; set; }
        public DbSet<JugadorEntity> Jugadores { get; set; }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PremierLeague.Data;

namespace PremierLeague.Migrations
{
    [DbContext(typeof(PremierLeagueDbContext))]
    partial class PremierLeagueDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PremierLeague.Data.Entities.EquipoEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("entrenador");

                    b.Property<string>("estadio");

                    b.Property<string>("fundacion");

                    b.Property<string>("info");

                    b.Property<string>("nombre")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("PremierLeague.Data.Entities.JugadorEntity", b =>
                {
                    b.Property<int?>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("altura");

                    b.Property<int?>("equipoId");

                    b.Property<int>("goles");

                    b.Property<string>("nombre")
                        .IsRequired();

                    b.Property<int>("numero");

                    b.Property<string>("pais");

                    b.Property<string>("posicion");

                    b.HasKey("id");

                    b.HasIndex("equipoId");

                    b.ToTable("Jugadores");
                });

            modelBuilder.Entity("PremierLeague.Data.Entities.JugadorEntity", b =>
                {
                    b.HasOne("PremierLeague.Data.Entities.EquipoEntity", "Equipo")
                        .WithMany("Jugadores")
                        .HasForeignKey("equipoId");
                });
#pragma warning restore 612, 618
        }
    }
}

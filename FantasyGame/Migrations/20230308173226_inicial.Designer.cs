﻿// <auto-generated />
using FantasyGame.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FantasyGame.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230308173226_inicial")]
    partial class inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FantasyGame.Entities.Campeonato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Campeao")
                        .HasMaxLength(350)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("IdTimeFutebol")
                        .HasColumnType("int");

                    b.Property<string>("Jogo")
                        .HasMaxLength(350)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Resultado")
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Terceiro")
                        .HasMaxLength(350)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Vice")
                        .HasMaxLength(350)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("IdTimeFutebol")
                        .IsUnique();

                    b.ToTable("Campeonato", (string)null);
                });

            modelBuilder.Entity("FantasyGame.Entities.TimeFutebol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NomeTime")
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Time", (string)null);
                });

            modelBuilder.Entity("FantasyGame.Entities.Campeonato", b =>
                {
                    b.HasOne("FantasyGame.Entities.TimeFutebol", "TimeFutebol")
                        .WithOne("Campeonato")
                        .HasForeignKey("FantasyGame.Entities.Campeonato", "IdTimeFutebol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TimeFutebol");
                });

            modelBuilder.Entity("FantasyGame.Entities.TimeFutebol", b =>
                {
                    b.Navigation("Campeonato");
                });
#pragma warning restore 612, 618
        }
    }
}

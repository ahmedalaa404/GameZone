﻿// <auto-generated />
using GameZone.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameZone.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231004234218_Init Create")]
    partial class InitCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameZone.Entity.Categoris", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Categoris");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Racing"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Fightng"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Film"
                        });
                });

            modelBuilder.Entity("GameZone.Entity.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Icone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Devices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Icone = "bi bi-playstation",
                            Name = "PlayStation"
                        },
                        new
                        {
                            Id = 2,
                            Icone = "bi bi-xbox",
                            Name = "XBox"
                        },
                        new
                        {
                            Id = 3,
                            Icone = "bi bi-pc-display-horizontal",
                            Name = "Pc"
                        },
                        new
                        {
                            Id = 4,
                            Icone = "bi bi-phone",
                            Name = "Phone"
                        },
                        new
                        {
                            Id = 5,
                            Icone = "bi bi-nintendo-switch",
                            Name = "Nintendo Switch"
                        });
                });

            modelBuilder.Entity("GameZone.Entity.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoreyId")
                        .HasColumnType("int");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("CategoreyId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GameZone.Entity.GameDevice", b =>
                {
                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("DeviceId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GameDevices");
                });

            modelBuilder.Entity("GameZone.Entity.Game", b =>
                {
                    b.HasOne("GameZone.Entity.Categoris", "Categorey")
                        .WithMany("Games")
                        .HasForeignKey("CategoreyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorey");
                });

            modelBuilder.Entity("GameZone.Entity.GameDevice", b =>
                {
                    b.HasOne("GameZone.Entity.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameZone.Entity.Game", "Game")
                        .WithMany("Devices")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("GameZone.Entity.Categoris", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("GameZone.Entity.Game", b =>
                {
                    b.Navigation("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}

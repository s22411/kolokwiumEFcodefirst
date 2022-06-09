﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using kolokwium.Models;

namespace kolokwium.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20220609075951_betterMig1")]
    partial class betterMig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("kolokwium.Models.Album", b =>
                {
                    b.Property<int>("IdAlbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AlbumName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IdMusicLabel")
                        .HasColumnType("int");

                    b.Property<int?>("MusicLabelIdMusicLabel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAlbum");

                    b.HasIndex("MusicLabelIdMusicLabel");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            IdAlbum = 1,
                            AlbumName = "Album 1",
                            IdMusicLabel = 1,
                            PublishDate = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdAlbum = 2,
                            AlbumName = "Album 2",
                            IdMusicLabel = 2,
                            PublishDate = new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            IdAlbum = 3,
                            AlbumName = "Album 3",
                            IdMusicLabel = 3,
                            PublishDate = new DateTime(2019, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("kolokwium.Models.MusicLabel", b =>
                {
                    b.Property<int>("IdMusicLabel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMusicLabel");

                    b.ToTable("MusicLabels");

                    b.HasData(
                        new
                        {
                            IdMusicLabel = 1,
                            Name = "Music Label 1"
                        },
                        new
                        {
                            IdMusicLabel = 2,
                            Name = "Music Label 2"
                        },
                        new
                        {
                            IdMusicLabel = 3,
                            Name = "Music Label 3"
                        });
                });

            modelBuilder.Entity("kolokwium.Models.Musician", b =>
                {
                    b.Property<int>("IdMusician")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMusician");

                    b.ToTable("Musicians");

                    b.HasData(
                        new
                        {
                            IdMusician = 1,
                            FirstName = "John",
                            LastName = "Smith",
                            Nickname = "JSmith"
                        },
                        new
                        {
                            IdMusician = 2,
                            FirstName = "Mary",
                            LastName = "Jane",
                            Nickname = "MJane"
                        },
                        new
                        {
                            IdMusician = 3,
                            FirstName = "Bob",
                            LastName = "Dylan",
                            Nickname = "BDylan"
                        },
                        new
                        {
                            IdMusician = 4,
                            FirstName = "John",
                            LastName = "Lennon",
                            Nickname = "JLennon"
                        });
                });

            modelBuilder.Entity("kolokwium.Models.Musician_Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .HasColumnType("int");

                    b.Property<int>("IdMusician")
                        .HasColumnType("int");

                    b.Property<int?>("MusicianIdMusician")
                        .HasColumnType("int");

                    b.Property<int?>("TrackIdTrack")
                        .HasColumnType("int");

                    b.HasKey("IdTrack", "IdMusician");

                    b.HasIndex("MusicianIdMusician");

                    b.HasIndex("TrackIdTrack");

                    b.ToTable("Musician_Tracks");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            IdMusician = 1
                        },
                        new
                        {
                            IdTrack = 1,
                            IdMusician = 3
                        },
                        new
                        {
                            IdTrack = 2,
                            IdMusician = 2
                        },
                        new
                        {
                            IdTrack = 2,
                            IdMusician = 3
                        },
                        new
                        {
                            IdTrack = 3,
                            IdMusician = 1
                        },
                        new
                        {
                            IdTrack = 3,
                            IdMusician = 3
                        });
                });

            modelBuilder.Entity("kolokwium.Models.Track", b =>
                {
                    b.Property<int>("IdTrack")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Duration")
                        .HasColumnType("real");

                    b.Property<int?>("IdMusicAlbum")
                        .HasColumnType("int");

                    b.Property<string>("TrackName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdTrack");

                    b.HasIndex("IdMusicAlbum");

                    b.ToTable("Tracks");

                    b.HasData(
                        new
                        {
                            IdTrack = 1,
                            Duration = 120f,
                            IdMusicAlbum = 1,
                            TrackName = "Track 1"
                        },
                        new
                        {
                            IdTrack = 2,
                            Duration = 180f,
                            IdMusicAlbum = 1,
                            TrackName = "Track 2"
                        },
                        new
                        {
                            IdTrack = 3,
                            Duration = 240f,
                            IdMusicAlbum = 1,
                            TrackName = "Track 3"
                        });
                });

            modelBuilder.Entity("kolokwium.Models.Album", b =>
                {
                    b.HasOne("kolokwium.Models.MusicLabel", "MusicLabel")
                        .WithMany("Albums")
                        .HasForeignKey("MusicLabelIdMusicLabel");

                    b.Navigation("MusicLabel");
                });

            modelBuilder.Entity("kolokwium.Models.Musician_Track", b =>
                {
                    b.HasOne("kolokwium.Models.Musician", "Musician")
                        .WithMany("Musician_Tracks")
                        .HasForeignKey("MusicianIdMusician");

                    b.HasOne("kolokwium.Models.Track", "Track")
                        .WithMany("Musician_Tracks")
                        .HasForeignKey("TrackIdTrack");

                    b.Navigation("Musician");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("kolokwium.Models.Track", b =>
                {
                    b.HasOne("kolokwium.Models.Album", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("IdMusicAlbum");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("kolokwium.Models.Album", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("kolokwium.Models.MusicLabel", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("kolokwium.Models.Musician", b =>
                {
                    b.Navigation("Musician_Tracks");
                });

            modelBuilder.Entity("kolokwium.Models.Track", b =>
                {
                    b.Navigation("Musician_Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}

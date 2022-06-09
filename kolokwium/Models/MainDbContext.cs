using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace kolokwium.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected MainDbContext()
        {
        }

        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Musician_Track> Musician_Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<MusicLabel> MusicLabels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Musician>(e => 
            {
                e.HasKey(m => m.IdMusician);
                e.Property(m => m.FirstName).HasMaxLength(30).IsRequired();
                e.Property(m => m.LastName).HasMaxLength(50).IsRequired();
                e.Property(m => m.Nickname).HasMaxLength(20);
                e.HasMany(m => m.Musician_Tracks).WithOne(t => t.Musician);

                e.HasData(
                    new Musician { IdMusician = 1, FirstName = "John", LastName = "Smith", Nickname = "JSmith" },
                    new Musician { IdMusician = 2, FirstName = "Mary", LastName = "Jane", Nickname = "MJane" },
                    new Musician { IdMusician = 3, FirstName = "Bob", LastName = "Dylan", Nickname = "BDylan" },
                    new Musician { IdMusician = 4, FirstName = "John", LastName = "Lennon", Nickname = "JLennon" },
                    new Musician { IdMusician = 5, FirstName = "Johnnnn", LastName = "Lennnnnon", Nickname = "JLeeennon" }
                );
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(t => t.IdTrack);
                e.Property(t => t.TrackName).HasMaxLength(20).IsRequired();
                e.Property(t => t.Duration).IsRequired();
                e.HasMany(t => t.Musician_Tracks).WithOne(m => m.Track);
                e.HasOne(t => t.Album).WithMany(a => a.Tracks).HasForeignKey(t => t.IdMusicAlbum);

                e.HasData(
                    new Track { IdTrack = 1, TrackName = "Track 1", Duration = 120, IdMusicAlbum = 1 },
                    new Track { IdTrack = 2, TrackName = "Track 2", Duration = 180, IdMusicAlbum = 1 },
                    new Track { IdTrack = 3, TrackName = "Track 3", Duration = 240, IdMusicAlbum = 1 }
                );
            });
            
            modelBuilder.Entity<Musician_Track>(e => 
            {
                e.HasKey(mt => new { mt.IdTrack, mt.IdMusician });
                e.HasOne(mt => mt.Track).WithMany(t => t.Musician_Tracks).HasForeignKey(mt => mt.IdTrack);
                e.HasOne(mt => mt.Musician).WithMany(m => m.Musician_Tracks).HasForeignKey(mt => mt.IdMusician);

                e.HasData(
                    new Musician_Track { IdTrack = 1, IdMusician = 1 },
                    new Musician_Track { IdTrack = 1, IdMusician = 3 },
                    new Musician_Track { IdTrack = 2, IdMusician = 2 },
                    new Musician_Track { IdTrack = 2, IdMusician = 3 },
                    new Musician_Track { IdTrack = 3, IdMusician = 1 },
                    new Musician_Track { IdTrack = 3, IdMusician = 3 }
                );
            });

            modelBuilder.Entity<Album>(e => 
            {
                e.HasKey(a => a.IdAlbum);
                e.Property(a => a.AlbumName).HasMaxLength(30).IsRequired();
                e.Property(a => a.PublishDate).IsRequired();
                e.HasOne(a => a.MusicLabel).WithMany(ml => ml.Albums);
                e.HasData(
                    new Album { IdAlbum = 1, AlbumName = "Album 1", PublishDate = new DateTime(2018, 1, 1), IdMusicLabel = 1 },
                    new Album { IdAlbum = 2, AlbumName = "Album 2", PublishDate = new DateTime(2020, 2, 1), IdMusicLabel = 2 },
                    new Album { IdAlbum = 3, AlbumName = "Album 3", PublishDate = new DateTime(2019, 3, 1), IdMusicLabel = 3 }
                );
            });

            modelBuilder.Entity<MusicLabel>(e => 
            {
                e.HasKey(ml => ml.IdMusicLabel);
                e.Property(ml => ml.Name).HasMaxLength(50).IsRequired();
                e.HasMany(ml => ml.Albums);

                e.HasData(
                    new MusicLabel { IdMusicLabel = 1, Name = "Music Label 1" },
                    new MusicLabel { IdMusicLabel = 2, Name = "Music Label 2" },
                    new MusicLabel { IdMusicLabel = 3, Name = "Music Label 3" }
                );
            });

        }
    }
}
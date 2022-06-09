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
                e.HasMany(m => m.Tracks).WithMany(t => t.Musicians);

                e.HasData(
                    new Musician { IdMusician = 1, FirstName = "John", LastName = "Smith", Nickname = "JSmith" },
                    new Musician { IdMusician = 2, FirstName = "Mary", LastName = "Jane", Nickname = "MJane" },
                    new Musician { IdMusician = 3, FirstName = "Bob", LastName = "Dylan", Nickname = "BDylan" },
                    new Musician { IdMusician = 4, FirstName = "John", LastName = "Lennon", Nickname = "JLennon" }
                );
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.HasKey(t => t.IdTrack);
                e.Property(t => t.TrackName).HasMaxLength(20).IsRequired();
                e.Property(t => t.Duration).IsRequired();
                e.HasMany(t => t.Musicians).WithMany(m => m.Tracks);

                e.HasData(
                    new Track { IdTrack = 1, TrackName = "Track 1", Duration = 120, IdMusicAlbum = 1 },
                    new Track { IdTrack = 2, TrackName = "Track 2", Duration = 180, IdMusicAlbum = 1 },
                    new Track { IdTrack = 3, TrackName = "Track 3", Duration = 240, IdMusicAlbum = 1 }
                );
            });
            

            modelBuilder.Entity<Album>(e => 
            {
                e.HasKey(a => a.IdAlbum);
                e.Property(a => a.AlbumName).HasMaxLength(30).IsRequired();
                e.Property(a => a.PublishDate).IsRequired();
                e.HasOne(a => a.MusicLabel).WithMany(ml => ml.Albums);
            });

            modelBuilder.Entity<MusicLabel>(e => 
            {
                e.HasKey(ml => ml.IdMusicLabel);
                e.Property(ml => ml.Name).HasMaxLength(50).IsRequired();
                e.HasMany(ml => ml.Albums);
            });

        }
    }
}
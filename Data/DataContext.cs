using AnotherMusicAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AnotherMusicAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }


        public DbSet<Music> Musics { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>()
                .HasMany(p => p.Musics)
                .WithMany(m => m.Playlists)
                .UsingEntity<PlaylistMusic>();
        }

    }
}
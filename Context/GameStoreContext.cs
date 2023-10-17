using GameStoreBeGNorbi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace GameStoreBeGNorbi.Context
{
    public class GameStoreContext : DbContext
    {
        public GameStoreContext(DbContextOptions options) : base(options) {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
        public DbSet<UserVideoGame> UserVideoGame => Set<UserVideoGame>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.VideoGames)
                .WithMany(e => e.Users)
                .UsingEntity<UserVideoGame>();
        }
    }
}

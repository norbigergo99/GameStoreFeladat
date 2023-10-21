using GameStoreBeGNorbi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace GameStoreBeGNorbi.Context
{
    public class GameStoreContext : DbContext
    {
        public GameStoreContext(DbContextOptions options) : base(options) {
        }

        public DbSet<User> Users { get; set; } 
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<UserVideoGame> UserVideoGame {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.VideoGames)
                .WithMany(e => e.Users)
                .UsingEntity<UserVideoGame>();
        }
    }
}

using System.Data.Entity;
using MediaPlayer.Data.Configuration;
using MediaPlayer.Data.Entities;
using MediaPlayer.Data.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MediaPlayer.Data
{
    public class ApplicationIdentityDbContext : IdentityDbContext<User>
    {
        public ApplicationIdentityDbContext()
            : base("DefaultConnection", false)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion
                    <ApplicationIdentityDbContext, Migrations.ApplicationIdentityDbContext.Configuration>());
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<CustomFile> Files { get; set; }

        public static ApplicationIdentityDbContext Create()
        {
            return new ApplicationIdentityDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CustomFileConfiguration());
        }
    }
}
using System.Data.Entity;
using MediaPlayer.Data.Entities;
using MediaPlayer.Data.Entities.Identity;
using MediaPlayer.Data.Migrations.ApplicationIdentityDbContext;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MediaPlayer.Data
{
    public class ApplicationIdentityDbContext : IdentityDbContext<User>
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public ApplicationIdentityDbContext()
            : base("DefaultConnection", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationIdentityDbContext, Configuration>());
        }

        public static ApplicationIdentityDbContext Create()
        {
            return new ApplicationIdentityDbContext();
        }

    }
}
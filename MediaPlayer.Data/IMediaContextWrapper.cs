using MediaPlayer.Data.DbContextWrapper;

namespace MediaPlayer.Data
{
    public interface IMediaContextWrapper : IDbContextWrapper<ApplicationIdentityDbContext>
    {
    }

    public class MediaContextWrapper : DbContextWrapper<ApplicationIdentityDbContext>,IMediaContextWrapper
    {
    }
}
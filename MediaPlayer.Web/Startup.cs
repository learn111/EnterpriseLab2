using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediaPlayer.Web.Startup))]
namespace MediaPlayer.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using AutoMapper;
using MediaPlayer.Cqrs;

namespace MediaPlayer.Web.App_Start
{
    public class AutomapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CqrsAutomapperConfig>();
                cfg.AddProfile<WebAutomapperConfig>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}
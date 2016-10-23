using AutoMapper;
using MediaPlayer.Cqrs.Aggregate;
using MediaPlayer.Web.Models;

namespace MediaPlayer.Web.App_Start
{
    public class WebAutomapperConfig:Profile
    {
        public WebAutomapperConfig()
        {
            CreateMap<SingerModel, SingerViewModels.SelectSingerViewModel>();
        }
    }
}
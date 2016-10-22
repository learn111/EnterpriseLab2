using System.Collections.Generic;
using AutoMapper;
using MediaPlayer.Cqrs.Aggregate;
using MediaPlayer.Data.Entities;

namespace MediaPlayer.Cqrs
{
    public class CqrsAutomapperConfig : Profile
    {
        public CqrsAutomapperConfig()
        {
            CreateMap<Genre, GenreModel>().ReverseMap();
        }
    }
}
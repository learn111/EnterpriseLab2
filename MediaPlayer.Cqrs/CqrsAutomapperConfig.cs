using AutoMapper;
using MediaPlayer.Cqrs.Aggregate;
using MediaPlayer.Cqrs.Command;
using MediaPlayer.Cqrs.Command.Tracks;
using MediaPlayer.Data.Entities;

namespace MediaPlayer.Cqrs
{
    public class CqrsAutomapperConfig : Profile
    {
        public CqrsAutomapperConfig()
        {
            #region Genres

            CreateMap<Genre, GenreModel>().ReverseMap();
            CreateMap<CreateGenreCommand, Genre>()
                .ForMember(d => d.GenreId, op => op.Ignore())
                .ForMember(d => d.Tracks, op => op.Ignore())
                .ForMember(d => d.GenreName, op => op.MapFrom(x => x.GenreName));
            CreateMap<int, Genre>().ConvertUsing(i => new Genre {GenreId = i});

            #endregion

            #region Tracks

            CreateMap<CreateTrackCommand, Track>()
                .ForMember(d => d.CustomFile, op => op.MapFrom(x => x))
                .ForMember(d => d.CustomFileId, op => op.Ignore())
                .ForMember(d => d.Playlists, op => op.Ignore())
                .ForMember(d => d.Singer, op => op.Ignore())
                .ForMember(d => d.TrackId, op => op.Ignore())
                .ForMember(d => d.Genres, op => op.MapFrom(x => x.GenreIds));

            #endregion

            #region Files

            CreateMap<CreateTrackCommand, CustomFile>()
                .ForMember(d => d.Track, op => op.Ignore())
                .ForMember(d => d.CustomFileId, op => op.Ignore())
                .ForMember(d => d.TrackId, op => op.Ignore());

            #endregion

            #region Singers
            CreateMap<Singer, SingerModel>(); 
            #endregion
        }
    }
}
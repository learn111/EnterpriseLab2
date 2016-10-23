using System.Collections.Generic;
using MediaPlayer.Cqrs.Command.Tracks;

namespace MediaPlayer.Web.Models
{
    public class TracksViewModels
    {
        public class CreateTrackViewModel
        {
            public CreateTrackCommand CreateTrackCommand { get; set; }
            public IEnumerable<GenreViewModels.SelectGenreViewModel> SelectGenreViewModels { get; set; }
            public IEnumerable<SingerViewModels.SelectSingerViewModel> SelectSingerViewModels { get; set; } 
        }
    }
}
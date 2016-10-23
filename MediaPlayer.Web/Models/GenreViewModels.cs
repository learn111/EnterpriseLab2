using System.ComponentModel.DataAnnotations;

namespace MediaPlayer.Web.Models
{
    public class GenreViewModels
    {
        public class SelectGenreViewModel
        {
            public int GenreId { get; set; }
            public string GenreName { get; set; }
            public bool IsSelected { get; set; }
        }
    }
}
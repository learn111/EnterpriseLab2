using System.ComponentModel.DataAnnotations;

namespace MediaPlayer.Cqrs.Aggregate
{
    public class GenreModel
    {
        public int GenreId { get; set; }
        [Display(Description = "Название")]
        public int GenreName { get; set; }
    }
}
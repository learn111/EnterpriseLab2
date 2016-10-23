using System.ComponentModel.DataAnnotations;
using MediaPlayer.Core.Cqrs.Contracts;

namespace MediaPlayer.Cqrs.Command
{
    public class CreateGenreCommand : ICommand
    {
        [Display(Name = "Название")]
        public string GenreName { get; set; }
    }
}
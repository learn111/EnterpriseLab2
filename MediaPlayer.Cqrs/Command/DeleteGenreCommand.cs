using MediaPlayer.Core.Cqrs.Contracts;

namespace MediaPlayer.Cqrs.Command
{
    public class DeleteGenreCommand : ICommand
    {
        public int GenreId { get; set; }
    }
}
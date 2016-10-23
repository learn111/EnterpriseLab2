using System.Collections.Generic;
using MediaPlayer.Core.Cqrs.Contracts;

namespace MediaPlayer.Cqrs.Command.Tracks
{
    public class CreateTrackCommand : ICommand
    {
        public string Name { get; set; }
        public bool IsShared { get; set; }
        public int SingerId { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public IEnumerable<int> GenreIds { get; set; }
    }
}
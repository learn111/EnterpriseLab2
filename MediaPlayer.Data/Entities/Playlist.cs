using System.Collections.Generic;

namespace MediaPlayer.Data.Entities
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
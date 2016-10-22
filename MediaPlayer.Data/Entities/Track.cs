using System.Collections.Generic;

namespace MediaPlayer.Data.Entities
{
    public class Track
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public bool IsShared { get; set; }
        public int SingerId { get; set; }
        public virtual Singer Singer { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
using System.Collections.Generic;

namespace MediaPlayer.Data.Entities
{
    public class Singer
    {
        public int SingerId { get; set; }
        public string SingerName { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
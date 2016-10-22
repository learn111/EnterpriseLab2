﻿using System.Collections.Generic;

namespace MediaPlayer.Data.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public int GenreName { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
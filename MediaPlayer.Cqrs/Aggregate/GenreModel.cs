﻿using System.ComponentModel.DataAnnotations;

namespace MediaPlayer.Cqrs.Aggregate
{
    public class GenreModel
    {
        public int GenreId { get; set; }
        [Display(Name = "Название")]
        public string GenreName { get; set; }
    }
}
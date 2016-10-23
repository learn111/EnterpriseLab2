using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaPlayer.Web.Models
{
    public class SingerViewModels
    {
        public class SelectSingerViewModel
        {
            public int SingerId { get; set; }
            public string SingerName { get; set; }
        }
    }
}
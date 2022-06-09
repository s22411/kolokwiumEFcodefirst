using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models.DTOs
{
    public class GetMusicianDTO
    {
        public Musician Musician { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ConcertDetails
    {
        public ConcertDetails(
            string artist,
            string tour,
            string venue)
        {
            Artist = artist;
            Tour = tour;
            Venue = venue;
        }

        public string Artist { get; set; }
        public string Tour { get; set; }
        public string Venue { get; set; }
    }
}

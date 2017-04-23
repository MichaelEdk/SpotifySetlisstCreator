using System.Collections.Generic;

namespace Models
{
    public interface ISong
    {
        string Title { get; set; }
        int Minutes { get; set; }
        IEnumerable<string> Artists { get; set; }
        string Album { get; set; }
        string Uri { get; set; }
    }

    public class Song : ISong
    {
        public Song(
            string title,
            int minutes,
            IEnumerable<string> artists,
            string album,
            string uri)
        {
            Title = title;
            Minutes = minutes;
            Artists = artists;
            Album = album;
            Uri = uri;
        }

        public string Title { get; set; }
        public int Minutes { get; set; }
        public IEnumerable<string> Artists { get; set; }
        public string Album { get; set; }
        public string Uri { get; set; }
    }
}
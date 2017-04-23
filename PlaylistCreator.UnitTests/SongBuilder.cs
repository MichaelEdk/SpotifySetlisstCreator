using System.Collections.Generic;
using Models;

namespace PlaylistCreator.UnitTests
{
    public interface ISongBuilder
    {
        ISong Build();
        ISongBuilder WithTitle(string title);
        ISongBuilder WithMinutes(int minutes);
        ISongBuilder WithArtist(string artist);
        ISongBuilder WithAlbum(string album);
        ISongBuilder WithUri(string uri);
    }

    public class SongBuilder : ISongBuilder
    {
        private string _title;
        private int _minutes;
        private readonly IList<string> _artists = new List<string>();
        private string _album;
        private string _uri;

        public ISong Build()
        {
            return new Song(
                _title,
                _minutes,
                _artists,
                _album,
                _uri);
        }

        public ISongBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public ISongBuilder WithMinutes(int minutes)
        {
            _minutes = minutes;
            return this;
        }

        public ISongBuilder WithArtist(string artist)
        {
            _artists.Add(artist);
            return this;
        }

        public ISongBuilder WithAlbum(string album)
        {
            _album = album;
            return this;
        }

        public ISongBuilder WithUri(string uri)
        {
            _uri = uri;
            return this;
        }
    }
}
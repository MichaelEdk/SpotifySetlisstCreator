using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Models;

namespace SetlistSpotifyPlaylistCreator
{
    public class SpotifyGrabber
    {
        private static SpotifyWebAPI _spotify;

        public async void LogInSpotify()
        {
            _spotify = new SpotifyWebAPI
            {
                UseAuth = true
            };

            WebAPIFactory webApiFactory = new WebAPIFactory(
                 "http://localhost",
                 8000,
                 "03701354f83c47e2b0320a17c6edd1db",
                 Scope.PlaylistModifyPublic,
                 TimeSpan.FromSeconds(20)
            );

            try
            {
                _spotify = await webApiFactory.GetWebApi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void CreatePlaylist(string playlistName, List<string> songUris, string artist)
        {
            var userId = _spotify.GetPrivateProfile().Id;
            var playlist = _spotify.CreatePlaylist(userId, playlistName);

            _spotify.AddPlaylistTracks(userId, playlist.Id, songUris);
        }

        public static void PopulateConcertSongList(IConcert concert, IList<string> songList)
        {
            var concertSongList = new List<ISong>();
            foreach (var songTitle in songList)
            {
                var track = SearchSpotify(songTitle, concert.ConcertDetails.Artist);
                if (track != null)
                {
                    var artists = track.Artists.Select(artist => artist.Name);
                    var song = new Song(
                        track.Name,
                        track.DurationMs,
                        artists,
                        track.Album.Name,
                        track.Uri);
                    concertSongList.Add(song);
                }
            }

            concert.SongList = concertSongList;
        }

        private static FullTrack SearchSpotify(string trackTitle, string artist)
        {
            // If we can find a song that matches the title and the artist, use that
            var searchString = $"{trackTitle} {artist}";
            var songAndArtistSearchResult = _spotify.SearchItems(searchString, SearchType.Track, 10).Tracks;
            var songAndArtistMatch = songAndArtistSearchResult?.Items.FirstOrDefault(track =>
                string.Equals(
                    track.Name.Substring(0, trackTitle.Length),
                    trackTitle,
                    StringComparison.OrdinalIgnoreCase) &&
                string.Equals(
                    track.Artists[0].Name,
                    artist,
                    StringComparison.OrdinalIgnoreCase));

            if (songAndArtistMatch != null)
            {
                return songAndArtistMatch;
            }

            // If that doesn't work, just search for the song title
            var songSearchResult = _spotify.SearchItems(trackTitle, SearchType.Track, 5).Tracks;
            var titleMatch = songSearchResult?.Items.FirstOrDefault(track =>
                string.Equals(
                    track.Name,
                    trackTitle,
                    StringComparison.Ordinal
                ));

            // If there's a song that matches the title, use that. Otherwise, just spurt out the first thing from the
            // more general search
            return titleMatch ?? songSearchResult?.Items.FirstOrDefault();
        }
    }
}

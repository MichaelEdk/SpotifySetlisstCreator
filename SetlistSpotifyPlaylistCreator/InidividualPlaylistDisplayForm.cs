using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Models;

namespace SetlistSpotifyPlaylistCreator
{
    public partial class InidividualPlaylistDisplayForm : Form
    {
        private readonly IConcert _concert;
        private const string SpotifySuccessMessage = "It worked! It really worked! (Maybe, check Spotify).";

        public InidividualPlaylistDisplayForm(IConcert concert)
        {
            InitializeComponent();
            _concert = concert;
            PopulateIndividualPlaylistListView(concert);
        }

        private void PopulateIndividualPlaylistListView(IConcert concert)
        {
            var songListViewItems = new List<ListViewItem>();

            foreach (var song in concert.SongList)
            {
                var songListViewItem = new ListViewItem(song.Title);
                songListViewItem.SubItems.Add(string.Join(", ", song.Artists));
                songListViewItem.SubItems.Add(song.Album);
                songListViewItem.SubItems.Add(song.Minutes.ToString());

                songListViewItems.Add(songListViewItem);
            }

            individualPlaylistListView.Columns.Add("Title", -1, HorizontalAlignment.Center);
            individualPlaylistListView.Columns.Add("Artists", -1, HorizontalAlignment.Center);
            individualPlaylistListView.Columns.Add("Album", -1, HorizontalAlignment.Center);
            individualPlaylistListView.Columns.Add("Duration", -1, HorizontalAlignment.Center);

            individualPlaylistListView.Items.AddRange(songListViewItems.ToArray());

            individualPlaylistListView.Columns[0].Width = -1;
            individualPlaylistListView.Columns[1].Width = -1;
            individualPlaylistListView.Columns[2].Width = -1;
            individualPlaylistListView.Columns[3].Width = -1;
        }

        private void generatePlaylistButton_Click(object sender, EventArgs e)
        {
            var songUriList = _concert.SongList.Select(song => song.Uri).ToList();
            SpotifyGrabber.CreatePlaylist(_concert.Title, songUriList, _concert.ConcertDetails.Artist);
            MessageBox.Show(SpotifySuccessMessage);
        }
    }
}

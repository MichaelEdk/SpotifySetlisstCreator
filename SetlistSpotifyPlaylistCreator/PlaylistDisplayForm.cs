using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Models;

namespace SetlistSpotifyPlaylistCreator
{
    public partial class PlaylistDisplayForm : Form
    {
        private IList<IConcert> _concertList;
        

        public PlaylistDisplayForm()
        {
            InitializeComponent();
            var spotify = new SpotifyGrabber();
            spotify.LogInSpotify();
            
            concertListView.Click += ConcertListViewOnClick;
        }

        private void ConcertListViewOnClick(object sender, EventArgs eventArgs)
        {
            var selectedItem = concertListView.SelectedItems[0];
            var concert = (IConcert) selectedItem.Tag;

            var playlistInfo = SetlistGrabber.GetPaylistInfo(concert);
            SpotifyGrabber.PopulateConcertSongList(concert, playlistInfo.Value);

            var playListForm = new InidividualPlaylistDisplayForm(concert);
            playListForm.ShowDialog();
        }

        private void DisplaySetlists()
        {
            _concertList = SetlistGrabber.CreateConcerts();

            var concertListViewItems = new List<ListViewItem>();

            foreach (var concert in _concertList)
            {
                var listViewItem = new ListViewItem(concert.Title);
                listViewItem.SubItems.Add(concert.ConcertDate.ToLongDateString());
                listViewItem.Tag = concert;
                concertListViewItems.Add(listViewItem);
            }

            concertListView.Columns.Add("Concert", -1, HorizontalAlignment.Center);
            concertListView.Columns.Add("Date", -1, HorizontalAlignment.Center);

            concertListView.Items.AddRange(concertListViewItems.ToArray());

            concertListView.Columns[0].Width = -1;
            concertListView.Columns[1].Width = -1;
        }

        private void populateSetlistButton_Click(object sender, EventArgs e)
        {
            var url = urlTextbox.Text;
            SetlistGrabber.InitialiseDriver(url);
            DisplaySetlists();
        }
    }
}

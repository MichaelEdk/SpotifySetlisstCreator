using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using Models;
using WebNavigator;

namespace SetlistSpotifyPlaylistCreator
{
    internal static class SetlistGrabber
    {
        private static IWebDriver _driver;

        public static void InitialiseDriver(string url)
        {
            Driver.Url = url;
        }

        public static IList<IConcert> CreateConcerts()
        {
            IList<IConcert> concertList = new List<IConcert>();
            var setlist = GrabSetlist(_driver);
            foreach (var set in setlist)
            {
                var title = set.FindElement(By.CssSelector("a.summary.url")).Text;
                var details = set.FindElements(By.CssSelector("div.details > span"));
                var concertDetails = GetDetails(details);

                var year = set.GetStringByClass("year");
                var month = set.GetStringByClass("month");
                var day = set.GetStringByClass("day");

                IConcert concert = new Concert(title, concertDetails, month, day, year);
                concertList.Add(concert);
            }
            return concertList;
        }

        public static KeyValuePair<string, IList<string>> GetPaylistInfo(IConcert concert)
        {
            var setLists = _driver.FindElements(By.CssSelector("div.col-xs-12.setlistPreview.vevent"));
            var setListBlock = setLists.FirstOrDefault(element => element.DateMatch(concert));

            setListBlock?.FindElement(By.LinkText(concert.Title)).Click();

            IEnumerable<IWebElement> setlistSongs = _driver.FindElements(By.ClassName("songLabel"));

            IList<string> songList = new List<string>();

            setlistSongs.ToList().ForEach(song => songList.Add(song.Text));

            _driver.Navigate().Back();

            return new KeyValuePair<string, IList<string>>(concert.Title, songList);
        }

        private static IEnumerable<IWebElement> GrabSetlist(ISearchContext driver)
        {
            return driver.FindElements(By.CssSelector("div.col-xs-12.setlistPreview.vevent"));
            //var years = setlistLines.Where(listItem => listItem.IsThisYear() && !listItem.IsTextEmpty("setSummary")).ToList();
            //return years;
        }

        private static ConcertDetails GetDetails(IEnumerable<IWebElement> details)
        {
            IDictionary<string, string> detailsDictionary = new Dictionary<string, string>();

            details.ToList().ForEach(we => 
                detailsDictionary.Add(
                    we.Text.Split(':')[0].Trim(),
                    we.Text.Split(':')[1].Trim())
                );

            string tour;
            string venue;
            string artist;

            detailsDictionary.TryGetValue("Artist", out artist);
            detailsDictionary.TryGetValue("Tour", out tour);
            detailsDictionary.TryGetValue("Venue", out venue);

            return new ConcertDetails(artist, tour, venue);
        }

        private static IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new ChromeDriver();
                }
                return _driver;
            }
        }
    }
}

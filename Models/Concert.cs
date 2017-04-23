using System;
using System.Collections.Generic;
using System.Globalization;


namespace Models
{
    public interface IConcert
    {
        DateTime ConcertDate { get; set; }
        string Title { get; set; }
        ConcertDetails ConcertDetails { get; set; }
        IEnumerable<ISong> SongList { get; set; }
    }

    public class Concert : IConcert
    {
        public Concert() { }

        public Concert(
            string title,
            ConcertDetails concertDetails,
            string month,
            string day,
            string year)
        {
            Title = title;
            ConcertDetails = concertDetails;

            var intMonth = DateTime.ParseExact(month, "MMM", CultureInfo.InvariantCulture).Month;
            var intDay = int.Parse(day);
            var intYear = int.Parse(year);

            ConcertDate = new DateTime(intYear, intMonth, intDay);
        }
        
        public string Title { get; set; }

        public ConcertDetails ConcertDetails { get; set; }

        public DateTime ConcertDate { get; set; }

        public IEnumerable<ISong> SongList { get; set; }
    }
}

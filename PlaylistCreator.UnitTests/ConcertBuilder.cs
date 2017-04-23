using System;
using Models;

namespace PlaylistCreator.UnitTests
{
    internal interface IConcertBuilder
    {
        IConcert Build();
        IConcertBuilder WithArtist(string artist);
        IConcertBuilder WithConcertDate(DateTime concertDate);
        IConcertBuilder WithTitle(string title);
        IConcertBuilder WithTour(string tour);
    }

    internal sealed class ConcertBuilder : IConcertBuilder
    {
        private string _artist;
        private DateTime _concertDate;
        private string _title;
        private string _tour;

        public IConcert Build()
        {
            return new Concert();
            //return new Concert(
            //    _title,
            //    _artist,
            //    _tour,
            //    _concertDate.Month.ToString(),
            //    _concertDate.Day.ToString(),
            //    _concertDate.Year.ToString()
            //    );
        }

        public IConcertBuilder WithArtist(string artist)
        {
            _artist = artist;
            return this;
        }

        public IConcertBuilder WithConcertDate(DateTime concertDate)
        {
            _concertDate = concertDate;
            return this;
        }

        public IConcertBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public IConcertBuilder WithTour(string tour)
        {
            _tour = tour;
            return this;
        }
    }
}

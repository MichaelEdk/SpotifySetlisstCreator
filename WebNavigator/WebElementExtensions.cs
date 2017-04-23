using OpenQA.Selenium;
using System;
using System.Globalization;
using Models;

namespace WebNavigator
{
    public static class WebElementExtensions
    {
        public static bool IsThisYear(this IWebElement webElement)
        {
            return string.Equals(webElement.FindElement(By.ClassName("year")).Text,
                "2017",
                StringComparison.Ordinal);
        }

        public static string GetStringByClass(this IWebElement webElement, string className)
        {
            return webElement.FindElement(By.ClassName(className)).Text;
        }

        public static bool IsTextEmpty(this IWebElement webElement, string className)
        {
            return string.IsNullOrEmpty(GetStringByClass(webElement, className));
        }

        public static bool DateMatch(this IWebElement webElement, IConcert concert)
        {
            var month = webElement.FindElement(By.ClassName("month")).Text;
            var day = webElement.FindElement(By.ClassName("day")).Text;
            var year = webElement.FindElement(By.ClassName("year")).Text;

            var intMonth = DateTime.ParseExact(month, "MMM", CultureInfo.InvariantCulture).Month;
            var intDay = int.Parse(day);
            var intYear = int.Parse(year);

            var date = new DateTime(intYear, intMonth, intDay);

            return date == concert.ConcertDate;
        }
    }
}

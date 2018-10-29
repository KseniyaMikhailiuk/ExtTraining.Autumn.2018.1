using System;
using System.Globalization;

namespace BookLibrary
{
    public class Book: IFormattable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string PublishingHouse { get; set; }
        public string Edition { get; set; }
        public string Pages { get; set; }
        public string Price { get; set; }

        public Book(string title, string author, string year, string publishingHouse, string edition, string pages, string price)
        {
            Title = title;
            Author = author;
            Year = year;
            PublishingHouse = publishingHouse;
            Edition = edition;
            Pages = pages;
            Price = price;
        }

        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return ToString(format, new FormatProvider());
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format)) format = "G";
            if (formatProvider == null) formatProvider = new FormatProvider();
            ICustomFormatter fp = new FormatProvider();
            return fp.Format(format, this, formatProvider);
        }
    }
}

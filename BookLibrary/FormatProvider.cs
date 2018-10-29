using System;

namespace BookLibrary
{
    class FormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            Book book = (Book)arg;
            switch (format.ToUpperInvariant())
            {
                case "G":
                    return string.Join(", ", book.Author, book.Title, book.Year, book.PublishingHouse, book.Edition, book.Pages, book.Price); ;
                case "ATYPH":
                    return string.Join(", ", book.Author, book.Title, book.Year, book.PublishingHouse); ;
                case "ATY":
                    return string.Join(", ", book.Author, book.Title, book.Year); ;
                case "AT":
                    return string.Join(", ", book.Author, book.Title);
                case "TYPH":
                    return string.Join(", ", book.Title, book.Year, book.PublishingHouse);
                case "T":
                    return book.Title;
                default:
                    throw new FormatException(string.Format("The {0} format string is not supported.", format));
            }
        }
    }
}

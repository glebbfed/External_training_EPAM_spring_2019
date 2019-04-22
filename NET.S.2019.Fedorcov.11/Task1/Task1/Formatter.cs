using System;

namespace Task1
{
    public static class Formater
    {
        public static string Format(string format, Book book)
        {
            switch (format)
            {
                case "1": return "Book: " + book.Title + " Author: " + book.Author;
                case "2": return "Book: " + book.Title + " Author: " + book.Author + " ISBN: " + book.ISBN;
                default: throw new FormatException(String.Format("The format of '{0}' is invalid.", format));
            }
        }

    }
}
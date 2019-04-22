using System;

namespace Task1
{
    public class Book: IComparable, IEquatable<Book>
    {
        public string ISBN { get; private set; }
        public string Author { get; private set; }
        public string Title { get; private set; }
        public string Edition { get; private set; }
        public int YearOfEdition { get; private set; }
        public int NumberOfPages { get; private set; }
        public double Price { get; private set; }

        public Book(string isbn, string author, string title, string edition, int yearOfEdition, int numberOfPages, double price)
        {
            ISBN = isbn;
            Author = author;
            Title = title;
            Edition = edition;
            YearOfEdition = yearOfEdition;
            NumberOfPages = numberOfPages;
            Price = price;
        }

        public override string ToString()
        {
            return "ISBN: " + ISBN + " Author: " + Author + " Title: " + Title + " Edition " + Edition + " The year of edition: " + YearOfEdition.ToString() + " Price: " + Price;

        }

        public string ToString(string format)
        {
            if (format == null || format == "")
                format = "1";


            switch (format)
            {
                case "1": return "Book: " + Title + " Author: " + Author;
                case "2": return "Book: " + Title + " Author: " + Author + " ISBN: " + ISBN;
                case "3": return "Book: " + Title + " Author: " + Author + " " + YearOfEdition.ToString() + " y." + " ISBN: " + ISBN;
                case "4": return "Book: " + Title + " Author: " + YearOfEdition.ToString() + " y. " + NumberOfPages.ToString() + " p. " + Author + " ISBN: " + ISBN;
                default: throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj.GetType() == GetType())
            {
                Book book = obj as Book;
                return Equals(book);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return ISBN.GetHashCode() + Title.GetHashCode() + YearOfEdition.GetHashCode();
        }

        public int CompareTo(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                return 1;
            }

            return string.Compare(book.Title, Title);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 1;
            }

            var book = (Book)obj;

            return CompareTo(book);
        }

        public bool Equals(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                return false;
            }

            if (ReferenceEquals(book, this))
            {
                return true;
            }

            if (book.GetType() == GetType())
            {
                Book book2 = book as Book;
                return Equals(book2);
            }

            return false;

        }




    }
}

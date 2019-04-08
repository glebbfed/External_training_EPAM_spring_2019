using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    public enum BookTags
    {
        isbn,
        author,
        name,
        edition,
        yearOfEdition,
        pages,
        price,
    }
    public static class BookListService
    {
        
        public static void AddBook(Book book, List<Book> listOfBooks)
        {
            if (!listOfBooks.Contains(book))
                listOfBooks.Add(book);
            else
                throw new ArgumentException("The book is already on the list.");
        }
        public static void RemoveBook(Book book, List<Book> listOfBooks)
        {
            if (listOfBooks.Contains(book))
                listOfBooks.Remove(book);
            else
                throw new ArgumentException("This book is not listed.");

        }
        public static Book FindByTag(Book book, List<Book> listOfBook)
        {
            return book;
        }
        public static void SortBooksByTag(BookTags tagName, List<Book> listOfBooks)
        {
            switch (tagName)
            {
                case BookTags.isbn:
                    listOfBooks = listOfBooks.OrderBy(orderTag => orderTag.ISBN).ToList();
                    break;

                case BookTags.name:
                    listOfBooks = listOfBooks.OrderBy(orderTag => orderTag.Title).ToList();
                    break;

                case BookTags.author:
                    listOfBooks = listOfBooks.OrderBy(orderTag => orderTag.Author).ToList();
                    break;

                case BookTags.edition:
                    listOfBooks = listOfBooks.OrderBy(orderTag => orderTag.Edition).ToList();
                    break;

                case BookTags.yearOfEdition:
                    listOfBooks = listOfBooks.OrderBy(orderTag => orderTag.YearOfEdition).ToList();
                    break;

                case BookTags.pages:
                    listOfBooks = listOfBooks.OrderBy(orderTag => orderTag.NumberOfPages).ToList();
                    break;

                case BookTags.price:
                    listOfBooks = listOfBooks.OrderBy(orderTag => orderTag.Price).ToList();
                    break;
            }
        }

        public static List<Book> FindBookByTag(BookTags tagName, string tagValue, List<Book> listOfBooks)
        {
            if (tagValue == null)
            {
                throw new ArgumentNullException();
            }

            if (tagValue == "")
            {
                throw new ArgumentException();
            }

            List<Book> foundBooks = new List<Book>();
            int tagDigitalValue;

            switch (tagName)
            {
                case BookTags.isbn:
                    foreach (Book book in listOfBooks)
                    {
                        if (book.ISBN == tagValue)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.author:
                    foreach (Book book in listOfBooks)
                    {
                        if (book.Author == tagValue)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.name:
                    foreach (Book book in listOfBooks)
                    {
                        if (book.Title == tagValue)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.edition:

                    foreach (Book book in listOfBooks)
                    {
                        if (book.Edition == tagValue)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.yearOfEdition:

                    foreach (Book book in listOfBooks)
                    {
                        if (book.YearOfEdition== int.Parse(tagValue))
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.pages:
                    tagDigitalValue = int.Parse(tagValue);

                    foreach (Book book in listOfBooks)
                    {
                        if (book.NumberOfPages == tagDigitalValue)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;

                case BookTags.price:
                    double tagValuePrice;

                    try
                    {
                        tagValuePrice = double.Parse(tagValue);
                    }
                    catch
                    {
                        throw new ArgumentException();
                    }

                    foreach (Book book in listOfBooks)
                    {
                        if (book.Price == tagValuePrice)
                        {
                            foundBooks.Add(book);
                        }
                    }

                    break;
            }

            return foundBooks;
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace Task1
{
    public class BookStorage
    {
        public string Path {get; set; }
        private List<Book> listOfBook = new List<Book>();
        public BookStorage(string path)
        {
            Path = path;

        }
        public void SaveToFile()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(Path, FileMode.OpenOrCreate)))
            {
                foreach (Book b in listOfBook)
                {
                    writer.Write(b.ISBN);
                    writer.Write(b.Author);
                    writer.Write(b.Title);
                    writer.Write(b.Edition);
                    writer.Write(b.YearOfEdition);
                    writer.Write(b.NumberOfPages);
                    writer.Write(b.Price);
                }
            }
        }

        public void LoadFromFile()
        {
            using (BinaryReader reader = new BinaryReader(File.Open(Path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    string isbn = reader.ReadString();
                    string author = reader.ReadString();
                    string title = reader.ReadString();
                    string edition = reader.ReadString();
                    int yearOfEdition = reader.ReadInt32();
                    int numberOfPages = reader.ReadInt32();
                    double price = reader.ReadDouble();
                    Book book = new Book(isbn, author, title, edition, yearOfEdition, numberOfPages, price);
                    BookListService.AddBook(book, listOfBook);
                }
            }
        }

        public void SortStorageByTag(BookTags tag)
        {
            BookListService.SortBooksByTag(tag, listOfBook);
        }

        public List<Book> FindInStorageByTag(BookTags tag, string tagvalue)
        {
            return BookListService.FindBookByTag(tag, tagvalue, listOfBook);
        }

        public void AddToStorage(Book book)
        {
            BookListService.AddBook(book, listOfBook);
        }
        
        public void RemoveFromStorage(Book book)
        {
            BookListService.RemoveBook(book, listOfBook);
        }
        public void DisplayStorage()
        {
            foreach(Book book in listOfBook)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}

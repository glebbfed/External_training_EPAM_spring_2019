using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            BookStorage storage = new BookStorage(@"C:\Users\Labrador\Desktop\EPAM\NET.S.2019.Fedorcov.8\Task1\storage.dat");
            Book book = new Book("92121212", "Author", "Title", "Edition1", 1984, 202, 20);
            Book book2 = new Book("232323", "Author2", "Title13123", "Edition2", 1985, 200, 15);
            Book book3 = new Book("343434", "Author3", "Title2", "Edition3", 1981, 230, 232);
            Book book4 = new Book("4545435", "Author", "Title", "Edition4", 1972, 391, 4);
            storage.AddToStorage(book);
            storage.AddToStorage(book2);
            storage.AddToStorage(book3);
            storage.AddToStorage(book4);
            foreach (Book b in storage.FindInStorageByTag(BookTags.author, "Author3243"))
            {
                Console.WriteLine(b.ToString());
            }
            storage.SortStorageByTag(BookTags.price);
            storage.DisplayStorage();
            storage.SaveToFile();
            storage.RemoveFromStorage(book);
            storage.DisplayStorage();
            Console.ReadLine();
        }
    }
}

using System;

namespace Task1
{
    public static class Formater
    {
        public static Book BookFormat(this Book book)
        {
            if (book == null)
                throw new ArgumentNullException();
            book.Title = book.Title.ToUpper();
            return book;
        }

    }
}
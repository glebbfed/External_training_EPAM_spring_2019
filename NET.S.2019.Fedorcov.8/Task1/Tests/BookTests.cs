using NUnit.Framework;
using Task1;
using System;
using System.Globalization;

namespace Tests
{
    public class ToStingTests
    {
        Book book = new Book("3123213", "Djohn Alen", "Hopa", "PubliHouse", 1983, 200, 20);
        [TestCase("2", ExpectedResult = "Book: Hopa Author: Djohn Alen ISBN: 3123213")]
        [TestCase("3", ExpectedResult = "Book: Hopa Author: Djohn Alen 1983 y. ISBN: 3123213")]
        public string ToStringTest(string format) => book.ToString(format);
    }
}
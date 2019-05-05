using NUnit.Framework;
using System.Collections.Generic;
using Task3;
using System;

namespace Tests
{
    public class BinaryTreeTests
    {

        [TestCase]
        public void BinarySearchTreeIntComparerPreOrderBypassTest()
        {
            IntComparer comparer = new IntComparer();
            BinarySearchTree<int> tree = new BinarySearchTree<int>(8);
            tree.Insert(3, comparer);
            tree.Insert(1, comparer);
            tree.Insert(6, comparer);
            tree.Insert(4, comparer);
            tree.Insert(7, comparer);
            tree.Insert(10, comparer);
            tree.Insert(14, comparer);
            tree.Insert(13, comparer);

            IEnumerable<int> expected = new int[] { 8, 3, 1, 6, 4, 7, 10, 14, 13 };
            IEnumerable<int> actual = tree.PreOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeIntComparerInOrderBypassTest()
        {
            IntComparer comparer = new IntComparer();
            BinarySearchTree<int> tree = new BinarySearchTree<int>(8);
            tree.Insert(3, comparer);
            tree.Insert(1, comparer);
            tree.Insert(6, comparer);
            tree.Insert(4, comparer);
            tree.Insert(7, comparer);
            tree.Insert(10, comparer);
            tree.Insert(14, comparer);
            tree.Insert(13, comparer);

            IEnumerable<int> expected = new int[] { 1, 3, 4, 6, 7, 8, 10, 13, 14 };
            IEnumerable<int> actual = tree.InOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeIntComparerPostOrderBypassTest()
        {
            IntComparer comparer = new IntComparer();
            BinarySearchTree<int> tree = new BinarySearchTree<int>(8);
            tree.Insert(3, comparer);
            tree.Insert(1, comparer);
            tree.Insert(6, comparer);
            tree.Insert(4, comparer);
            tree.Insert(7, comparer);
            tree.Insert(10, comparer);
            tree.Insert(14, comparer);
            tree.Insert(13, comparer);

            IEnumerable<int> expected = new int[] { 1, 4, 7, 6, 3, 13, 14, 10, 8 };
            IEnumerable<int> actual = tree.PostOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeStringPreOrderBypassTest()
        {
            StrComparer comparer = new StrComparer();
            BinarySearchTree<string> tree = new BinarySearchTree<string>("abcdefgh");
            tree.Insert("abc", comparer);
            tree.Insert("a", comparer);
            tree.Insert("abcdef", comparer);
            tree.Insert("abcd", comparer);
            tree.Insert("abcdefg", comparer);
            tree.Insert("abcdefghij", comparer);
            tree.Insert("abcdefghijklmn", comparer);
            tree.Insert("abcdefghijklm", comparer);

            IEnumerable<string> expected = new string[] { "abcdefgh", "abc", "a", "abcdef", "abcd", "abcdefg", "abcdefghij", "abcdefghijklmn", "abcdefghijklm" };
            IEnumerable<string> actual = tree.PreOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeStringInOrderBypassTest()
        {
            StrComparer comparer = new StrComparer();
            BinarySearchTree<string> tree = new BinarySearchTree<string>("abcdefgh");
            tree.Insert("abc", comparer);
            tree.Insert("a", comparer);
            tree.Insert("abcdef", comparer);
            tree.Insert("abcd", comparer);
            tree.Insert("abcdefg", comparer);
            tree.Insert("abcdefghij", comparer);
            tree.Insert("abcdefghijklmn", comparer);
            tree.Insert("abcdefghijklm", comparer);

            IEnumerable<string> expected = new string[] { "a", "abc", "abcd", "abcdef", "abcdefg", "abcdefgh", "abcdefghij", "abcdefghijklm", "abcdefghijklmn" };
            IEnumerable<string> actual = tree.InOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreeStringPostOrderBypassTest()
        {
            StrComparer comparer = new StrComparer();
            BinarySearchTree<string> tree = new BinarySearchTree<string>("abcdefgh");
            tree.Insert("abc", comparer);
            tree.Insert("a", comparer);
            tree.Insert("abcdef", comparer);
            tree.Insert("abcd", comparer);
            tree.Insert("abcdefg", comparer);
            tree.Insert("abcdefghij", comparer);
            tree.Insert("abcdefghijklmn", comparer);
            tree.Insert("abcdefghijklm", comparer);

            IEnumerable<string> expected = new string[] { "a", "abcd", "abcdefg", "abcdef", "abc", "abcdefghijklm", "abcdefghijklmn", "abcdefghij", "abcdefgh" };
            IEnumerable<string> actual = tree.PostOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreePointPreOrderBypassTest()
        {
            PointComparer comparer = new PointComparer();
            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(new Point(Math.Sqrt(32), Math.Sqrt(32)));
            tree.Insert(new Point(Math.Sqrt(6), Math.Sqrt(3)), comparer);
            tree.Insert(new Point(0, 1), comparer);
            tree.Insert(new Point(Math.Sqrt(24), Math.Sqrt(12)), comparer);
            tree.Insert(new Point(Math.Sqrt(8), Math.Sqrt(8)), comparer);
            tree.Insert(new Point(Math.Sqrt(38), Math.Sqrt(11)), comparer);
            tree.Insert(new Point(Math.Sqrt(67), Math.Sqrt(33)), comparer);
            tree.Insert(new Point(Math.Sqrt(157), Math.Sqrt(39)), comparer);
            tree.Insert(new Point(Math.Sqrt(150), Math.Sqrt(19)), comparer);

            IEnumerable<Point> expected = new Point[]
            {
                new Point(Math.Sqrt(32), Math.Sqrt(32)),
                new Point(Math.Sqrt(6), Math.Sqrt(3)),
                new Point(0, 1),
                new Point(Math.Sqrt(24), Math.Sqrt(12)),
                new Point(Math.Sqrt(8), Math.Sqrt(8)),
                new Point(Math.Sqrt(38), Math.Sqrt(11)),
                new Point(Math.Sqrt(67), Math.Sqrt(33)),
                new Point(Math.Sqrt(157), Math.Sqrt(39)),
                new Point(Math.Sqrt(150), Math.Sqrt(19))
            };
            IEnumerable<Point> actual = tree.PreOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreePointInOrderBypassTest()
        {
            PointComparer comparer = new PointComparer();
            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(new Point(Math.Sqrt(32), Math.Sqrt(32)));
            tree.Insert(new Point(Math.Sqrt(6), Math.Sqrt(3)), comparer);
            tree.Insert(new Point(0, 1), comparer);
            tree.Insert(new Point(Math.Sqrt(24), Math.Sqrt(12)), comparer);
            tree.Insert(new Point(Math.Sqrt(8), Math.Sqrt(8)), comparer);
            tree.Insert(new Point(Math.Sqrt(38), Math.Sqrt(11)), comparer);
            tree.Insert(new Point(Math.Sqrt(67), Math.Sqrt(33)), comparer);
            tree.Insert(new Point(Math.Sqrt(157), Math.Sqrt(39)), comparer);
            tree.Insert(new Point(Math.Sqrt(150), Math.Sqrt(19)), comparer);

            IEnumerable<Point> expected = new Point[]
            {
                new Point(0, 1),
                new Point(Math.Sqrt(6), Math.Sqrt(3)),
                new Point(Math.Sqrt(8), Math.Sqrt(8)),
                new Point(Math.Sqrt(24), Math.Sqrt(12)),
                new Point(Math.Sqrt(38), Math.Sqrt(11)),
                new Point(Math.Sqrt(32), Math.Sqrt(32)),
                new Point(Math.Sqrt(67), Math.Sqrt(33)),
                new Point(Math.Sqrt(150), Math.Sqrt(19)),
                new Point(Math.Sqrt(157), Math.Sqrt(39))
            };
            IEnumerable<Point> actual = tree.InOrderBypass();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinarySearchTreePointPostOrderBypassTest()
        {
            PointComparer comparer = new PointComparer();
            BinarySearchTree<Point> tree = new BinarySearchTree<Point>(new Point(Math.Sqrt(32), Math.Sqrt(32)));
            tree.Insert(new Point(Math.Sqrt(6), Math.Sqrt(3)), comparer);
            tree.Insert(new Point(0, 1), comparer);
            tree.Insert(new Point(Math.Sqrt(24), Math.Sqrt(12)), comparer);
            tree.Insert(new Point(Math.Sqrt(8), Math.Sqrt(8)), comparer);
            tree.Insert(new Point(Math.Sqrt(38), Math.Sqrt(11)), comparer);
            tree.Insert(new Point(Math.Sqrt(67), Math.Sqrt(33)), comparer);
            tree.Insert(new Point(Math.Sqrt(157), Math.Sqrt(39)), comparer);
            tree.Insert(new Point(Math.Sqrt(150), Math.Sqrt(19)), comparer);

            IEnumerable<Point> expected = new Point[]
            {
                new Point(0, 1),
                new Point(Math.Sqrt(8), Math.Sqrt(8)),
                new Point(Math.Sqrt(38), Math.Sqrt(11)),
                new Point(Math.Sqrt(24), Math.Sqrt(12)),
                new Point(Math.Sqrt(6), Math.Sqrt(3)),
                new Point(Math.Sqrt(150), Math.Sqrt(19)),
                new Point(Math.Sqrt(157), Math.Sqrt(39)),
                new Point(Math.Sqrt(67), Math.Sqrt(33)),
                new Point(Math.Sqrt(32), Math.Sqrt(32))
            };
            IEnumerable<Point> actual = tree.PostOrderBypass();

            Assert.AreEqual(expected, actual);
        }

    }
}
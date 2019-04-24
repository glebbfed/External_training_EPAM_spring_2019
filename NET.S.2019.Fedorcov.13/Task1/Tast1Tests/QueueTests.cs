using NUnit.Framework;
using Task1;

namespace Tests
{
    public class Tests
    {
        [TestCase]
        public void EnqueueIntTest()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(3);
            Assert.AreEqual(3, queue.Peek());
        }

        [TestCase]
        public void DequeueIntTest()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(3);
            queue.Enqueue(4);
            Assert.AreEqual(3, queue.Dequeue());
        }

        [TestCase]
        public void EnqueueDoubleTest()
        {
            Queue<double> queue = new Queue<double>();
            queue.Enqueue(3.25);
            Assert.AreEqual(3.25, queue.Peek());
        }

        [TestCase]
        public void DequeueDoubleTest()
        {
            Queue<double> queue = new Queue<double>();
            queue.Enqueue(3.25);
            queue.Enqueue(4.25);
            Assert.AreEqual(3.25, queue.Dequeue());
        }

        [TestCase]
        public void IteratorIntTest1()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(3);
            var en = queue.GetEnumerator();
            en.Reset();
            Assert.AreEqual(3, en.Current);
        }

        [TestCase]
        public void IteratorIntTest2()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(3);
            var en = queue.GetEnumerator();
            en.Reset();
            queue.Enqueue(4);
            queue.Enqueue(5);
            en.MoveNext();
            Assert.AreEqual(4, en.Current);
        }

    }
}
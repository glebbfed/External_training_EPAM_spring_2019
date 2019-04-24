using System;

namespace Task1
{
    public class Queue<T>
    {
        private T[] array;
        private int head;
        private int tail;
        
        /// <summary>
        /// Count of elements in the queue.
        /// </summary>
        public int Count
        {
            get { return tail - head + 1; }
        }

        /// <summary>
        /// Constructor of queue
        /// </summary>
        public Queue()
        {
            array = new T[1];
            head = 0;
            tail = -1;
        }

        /// <summary>
        /// Method that adds an item to a queue.
        /// </summary>
        /// <param name="item">Item</param>
        public void Enqueue(T item)
        {
            T[] bufArray = new T[array.Length];
            bufArray = array;
            array = new T[array.Length + 1];
            for (int i = 0; i < bufArray.Length; i++)
                array[i] = bufArray[i];
            tail++;
            array[tail] = item;
        }

        /// <summary>
        /// Method that removes an item from the queue.
        /// </summary>
        /// <returns>Deleted item</returns>
        public T Dequeue()
        {
            if (Count <= 0)
                throw new InvalidOperationException();
            else
            {
                T result = array[head];
                array[head] = default(T);
                head++;
                return result;
            }
        }
        /// <summary>
        /// A method that returns an item in the head of a queue.
        /// </summary>
        /// <returns>Item in the head of a queue.</returns>
        public T Peek()
        {
            if (Count <= 0)
                throw new InvalidOperationException();
            else
                return array[head];
        }

        /// <summary>
        /// Iterator of an queue.
        /// </summary>
        /// <returns>Iterator</returns>
        public Iterator GetEnumerator()
        {
            return new Iterator(this);
        }

        public struct Iterator
        {
            private readonly Queue<T> queue;
            private int currentIndex;

            /// <summary>
            /// Constructor of an queue.
            /// </summary>
            /// <param name="collection">Queue</param>
            public Iterator(Queue<T> collection)
            {
                currentIndex = -1;
                queue = collection;
            }
            /// <summary>
            /// Current item.
            /// </summary>
            public T Current
            {
                get
                {
                    if (currentIndex == -1 || currentIndex == queue.Count)
                    {
                        throw new InvalidOperationException();
                    }
                    return queue.array[currentIndex];
                }
            }

            /// <summary>
            /// Reset current item to head of a queue.
            /// </summary>
            public void Reset()
            {
                currentIndex = queue.head;
            }

            /// <summary>
            /// Method that advances current in turn.
            /// </summary>
            public void MoveNext()
            {
                if (currentIndex + 1 < queue.Count)
                    currentIndex++;
                else
                    throw new InvalidOperationException();
            }
        }
    }
}

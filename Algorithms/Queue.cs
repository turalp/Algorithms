using System;

namespace Algorithms
{
    /// <summary>
    /// A data structure that works in a way of FIFO.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    public class Queue<T>
    {
        private Node _head;
        private Node _tail;

        /// <summary>
        /// Adds element to the queue.
        /// </summary>
        /// <param name="value">Value of new element.</param>
        public void Add(T value)
        {
            var newNode = new Node(value);

            if (_tail == null)
            {
                _tail = newNode;
            }

            _tail.Next = newNode;
            _tail = newNode;

            if (_head == null)
            {
                _head = _tail;
            }
        }

        /// <summary>
        /// Removes element from the queue.
        /// </summary>
        /// <returns>Removed value.</returns>
        public T Remove()
        {
            if (_head == null)
            {
                throw new NullReferenceException("Queue has no elements.");
            }

            T data = _head.Data;
            _head = _head.Next;

            if (_head == null)
            {
                _tail = null;
            }

            return data;
        }

        /// <summary>
        /// Gets a value for first element in the stack.
        /// </summary>
        /// <returns>Value of first element.</returns>
        public T Peek()
        {
            return _head.Data;
        }

        /// <summary>
        /// Checks is there any element in the stack.
        /// </summary>
        /// <returns>State of stack elements.</returns>
        public bool IsEmpty()
        {
            return _head == null;
        }

        /// <summary>
        /// Node of queue, represents an element.
        /// </summary>
        private class Node
        {
            public T Data { get; }
            public Node Next { get; set; }

            public Node(T data)
            {
                Data = data;
            }
        }
    }
}

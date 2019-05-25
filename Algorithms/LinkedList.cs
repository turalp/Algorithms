using System;

namespace Algorithms
{
    /// <summary>
    /// Data structure, where all elements are linked to next element in the row.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    public class LinkedList<T>
    {
        private Node _head;

        /// <summary>
        /// Adds element to the head of linked list.
        /// </summary>
        /// <param name="value">Value of element.</param>
        public void AddFront(T value)
        {
            var node = new Node(value);

            if (_head == null)
            {
                _head = node;
                return;
            }

            node.Next = _head;
            _head = node;
        }
        
        /// <summary>
        /// Gets first element of linked list.
        /// </summary>
        /// <exception cref="NullReferenceException">Empty list.</exception>
        /// <returns>First element.</returns>
        public T GetFirst()
        {
            if (_head == null)
            {
                throw new NullReferenceException("There is no element in the list.");
            }

            return _head.Data;
        }

        /// <summary>
        /// Gets last element of linked list.
        /// </summary>
        /// <exception cref="NullReferenceException">Empty list.</exception>
        /// <returns>Last element.</returns>
        public T GetLast()
        {
            if (_head == null)
            {
                throw new NullReferenceException("There is no element in the list.");
            }

            var current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            return current.Data;
        }

        /// <summary>
        /// Adds element to the tail of linked list.
        /// </summary>
        /// <param name="value">Value of element.</param>
        public void AddBack(T value)
        {
            var node = new Node(value);

            if (_head == null)
            {
                _head = node;
                return;
            }

            var current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = node;
        }

        /// <summary>
        /// Gets number of elements in linked list.
        /// </summary>
        /// <returns>Number of elements.</returns>
        public int Size()
        {
            if (_head == null)
            {
                return 0;
            }

            int size = 1;
            var current = _head;
            while (current.Next != null)
            {
                current = current.Next;
                size++;
            }

            return size;
        }

        /// <summary>
        /// Clear linked list.
        /// </summary>
        public void Clear()
        {
            _head = null;
        }

        /// <summary>
        /// Removes specified value from linked list.
        /// </summary>
        /// <param name="value"></param>
        public void Delete(T value)
        {
            if (_head == null)
            {
                throw new NullReferenceException("List has no elements.");
            }

            if (_head.Data.Equals(value))
            {
                _head = _head.Next;
            }

            Node current = _head;

            while (current.Next != null)
            {
                if (current.Next.Data.Equals(value))
                {
                    current.Next = current.Next.Next;
                    return;
                }

                current = current.Next;
            }
        }

        /// <summary>
        /// Node of linked list.
        /// </summary>
        private sealed class Node
        {
            private T _data;

            public T Data
            {
                get => _data;
                set
                {

                }
            }
            public Node Next { get; set; }

            public Node(T data)
            {
                _data = data;
            }
        }


    }
}

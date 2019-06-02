using System;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// A data structure that works in a way of LIFO.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    public class Stack<T>
    {
        private Node _head;

        /// <summary>
        /// Adds value to the stack.
        /// </summary>
        /// <param name="value">Value of element.</param>
        public void Push(T value)
        {
            var newNode = new Node(value) {Next = _head};

            _head = newNode;
        }

        /// <summary>
        /// Pops first element from stack.
        /// </summary>
        /// <returns>Value of element.</returns>
        public T Pop()
        {
            if (_head == null)
            {
                throw new NullReferenceException("Stack has no elements.");
            }

            T data = _head.Data;
            _head = _head.Next;

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
        /// Node of stack, considered as an element.
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

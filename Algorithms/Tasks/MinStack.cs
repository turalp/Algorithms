using System;

namespace Algorithms.Tasks
{
    /// <summary>
    /// Data structure of stack, in which operation of push(), pop() and min() is O(1).
    /// </summary>
    public class MinStack
    {
        private Node _head;

        /// <summary>
        /// Adds value to the stack.
        /// </summary>
        /// <param name="value">Value of element.</param>
        public void Push(int value)
        {
            int min = value;

            if (_head != null)
            {
                min = Math.Min(min, Min());
            }

            var newNode = new Node(value, min) { Next = _head };

            _head = newNode;
        }

        /// <summary>
        /// Pops first element from stack.
        /// </summary>
        /// <returns>Value of element.</returns>
        public int Pop()
        {
            if (_head == null)
            {
                throw new NullReferenceException("Stack has no elements.");
            }

            int data = _head.Data;
            _head = _head.Next;

            return data;
        }

        /// <summary>
        /// Finds minimum element of stack.
        /// </summary>
        /// <returns></returns>
        public int Min()
        {
            return _head.Min;
        }

        /// <summary>
        /// Node of stack, considered as an element.
        /// </summary>
        private class Node
        {
            public int Data { get; }
            public Node Next { get; set; }
            public int Min { get; }

            public Node(int data, int min)
            {
                Data = data;
                Min = min;
            }
        }
    }
}

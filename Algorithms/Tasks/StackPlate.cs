using System;
using System.Collections.Generic;

namespace Algorithms.Tasks
{
    /// <summary>
    /// Stack plate. When stack is overflowed, it creates new one.
    /// </summary>
    public class StackPlate
    {
        private readonly int _threshold;
        private readonly IList<Stack<int>> _stacks;

        public StackPlate(int threshold)
        {
            _threshold = threshold;
            _stacks = new List<Stack<int>>();
        }

        public void Push(int value)
        {
            var current = GetCurrentStack();
            if (current != null && current.Count < _threshold)
            {
                current.Push(value);
            }
            else
            {
                current = new Stack<int>();
                current.Push(value);
                _stacks.Add(current);
            }
        }

        public int Pop()
        {
            var current = GetCurrentStack();
            if (current == null)
            {
                throw new InsufficientExecutionStackException();
            }

            int data = current.Pop();
            if (current.Count == 0)
            {
                _stacks.Remove(current);
            }

            return data;
        }

        private Stack<int> GetCurrentStack()
        {
            return _stacks[_stacks.Count - 1];
        }
    }
}

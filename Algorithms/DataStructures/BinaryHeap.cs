using System;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Data structure that can find max/min by O(logN).
    /// </summary>
    /// <typeparam name="T">Type must derive from generic IComparable.</typeparam>
    public class BinaryHeap<T> where T : IComparable<T>
    {
        private static int _capacity;
        private int _size;
        private T[] _data = new T[_capacity];

        /// <summary>
        /// Gets left child of binary heap.
        /// </summary>
        /// <param name="parentIndex">Index of parent element.</param>
        /// <returns>Index of left child.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown, when one of the indexes is negative or greater than size of array.</exception>
        private int GetLeftChildIndex(int parentIndex)
        {
            if (parentIndex < 0 || parentIndex >= _size)
            {
                throw new IndexOutOfRangeException("Index cannot be a negative number or greater than size of binary heap.");
            }
            return 2 * parentIndex + 1;
        }

        /// <summary>
        /// Gets right child of binary heap.
        /// </summary>
        /// <param name="parentIndex">Index of parent element.</param>
        /// <returns>Index of right child.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown, when one of the indexes is negative or greater than size of array.</exception>
        private int GetRightChildIndex(int parentIndex)
        {
            if (parentIndex < 0 || parentIndex >= _size)
            {
                throw new IndexOutOfRangeException("Index cannot be a negative number or greater than size of binary heap.");
            }
            return 2 * parentIndex + 2;
        }

        /// <summary>
        /// Gets parent index of binary heap.
        /// </summary>
        /// <param name="childIndex">Index of one of the child element.</param>
        /// <returns>Index of parent element.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown, when one of the indexes is negative or greater than size of array.</exception>
        private int GetParentIndex(int childIndex)
        {
            if (childIndex < 0 || childIndex >= _size)
            {
                throw new IndexOutOfRangeException("Index cannot be a negative number or greater than size of binary heap.");
            }
            return (childIndex - 1) / 2;
        }

        /// <summary>
        /// Checks whether node has left child.
        /// </summary>
        /// <param name="index">Index of parent element.</param>
        /// <returns>True/False of left child existence.</returns>
        private bool HasLeftChild(int index) => GetLeftChildIndex(index) < _size;

        /// <summary>
        /// Checks whether node has right child.
        /// </summary>
        /// <param name="index">Index of parent element.</param>
        /// <returns>True/False of right child existence.</returns>
        private bool HasRightChild(int index) => GetRightChildIndex(index) < _size;

        /// <summary>
        /// Checks is there any parent of node.
        /// </summary>
        /// <param name="index">Index of suspicious to be child element.</param>
        /// <returns>True/False of parent existence.</returns>
        private bool HasParent(int index) => GetParentIndex(index) >= 0;

        /// <summary>
        /// Gets left child of binary heap node.
        /// </summary>
        /// <param name="index">Index of parent.</param>
        /// <returns>Left child of node.</returns>
        private T LeftChild(int index) => _data[GetLeftChildIndex(index)];

        /// <summary>
        /// Gets right child of binary heap node.
        /// </summary>
        /// <param name="index">Index of parent.</param>
        /// <returns>Right child of node.</returns>
        private T RightChild(int index) => _data[GetRightChildIndex(index)];

        /// <summary>
        /// Gets parent of binary heap node.
        /// </summary>
        /// <param name="index">Index of one of the children.</param>
        /// <returns>Parent of current node.</returns>
        private T Parent(int index) => _data[GetParentIndex(index)];

        /// <summary>
        /// Inserting value to appropriate position in binary heap.
        /// </summary>
        /// <param name="value">Value of node.</param>
        public void Insert(T value)
        {
            if (_size == _capacity)
            {
                ResizeCapacity();
            }

            _data[_size] = value;
            _size++;
            HeapifyUp();
        }

        /// <summary>
        /// Extracting max value from binary heap.
        /// </summary>
        /// <returns>Max value.</returns>
        /// <exception cref="NotSupportedException">Thrown, when binary heap's size is zero.</exception>
        public T ExtractMax()
        {
            if (_size == 0)
            {
                throw new NotSupportedException("Binary heap has no values.");
            }

            T value = _data[0];
            _data[0] = _data[_size - 1];
            _size--;
            HeapifyDown();

            return value;
        }

        /// <summary>
        /// Resize binary heap array with values.
        /// </summary>
        public void ResizeCapacity()
        {
            T[] newArray = new T[_capacity * 2];
            for (int i = 0; i < _data.Length; i++)
            {
                newArray[i] = _data[i];
            }

            _data = newArray;
            _capacity *= 2;
        }
        
        /// <summary>
        /// Walk upwards to the next node, while parents are less than current value.
        /// </summary>
        private void HeapifyUp()
        {
            int index = _size - 1;
            while (HasParent(index) && Parent(index).CompareTo(_data[index]) == -1)
            {
                Swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }

        /// <summary>
        /// Walk downwards to the next node, while children are greater than current value.
        /// </summary>
        private void HeapifyDown()
        {
            int index = 0;

            while (HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && RightChild(index).CompareTo(LeftChild(index)) == 1)
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }

                if (_data[index].CompareTo(_data[smallerChildIndex]) == 1)
                {
                    break;
                }
                else
                {
                    Swap(index, smallerChildIndex);
                }

                index = smallerChildIndex;
            }
        }

        /// <summary>
        /// Swaps a location of nodes by their indexes.
        /// </summary>
        /// <param name="fIndex">Index of first candidate to swap.</param>
        /// <param name="sIndex">Index of second candidate to swap.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown, when one of the indexes is negative or greater than size of array.</exception>
        private void Swap(int fIndex, int sIndex)
        {
            if ((fIndex < 0 || fIndex >= _size) || (sIndex < 0 || sIndex >= _size))
            {
                throw new IndexOutOfRangeException("Index cannot be a negative number or greater than size of binary heap.");
            }

            T value = _data[fIndex];
            _data[fIndex] = _data[sIndex];
            _data[sIndex] = value;
        }
    }
}

using System;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Represents array with dynamic capacity.
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    public class DynamicArray<T>
    {
        private int _capacity;
        private T[] _data;
        private int _size;

        public int Length
        {
            get => _size;
            private set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("Index of array cannot be negative value.");
                }
                _size = value;
            }
        }

        public DynamicArray(int capacity)
        {
            _capacity = capacity;
            _data = new T[capacity];
        }

        /// <summary>
        /// Gets value for specified index of array.
        /// </summary>
        /// <param name="index">Index of array.</param>
        /// <exception cref="IndexOutOfRangeException">Index cannot be negative.</exception>
        /// <returns>Value from specified position.</returns>
        private T GetValue(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index of array cannot be negative value.");
            }
            if (index > Length)
            {
                throw new IndexOutOfRangeException("Index is out of specified length.");
            }

            return _data[index];
        }

        /// <summary>
        /// Set relevant value to specified index.
        /// </summary>
        /// <param name="index">Number of position in array.</param>
        /// <param name="value">Value, which needs to be set.</param>
        private void SetValue(int index, T value)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index of array cannot be negative value.");
            }
            if (Length == _capacity)
            {
                Resize();
            }
            
            for(int i = Length; i > index; i--)
            {
                _data[i] = _data[i - 1];
            }
            _data[index] = value;
            Length++;
        }

        /// <summary>
        /// Increases capacity of dynamic array.
        /// </summary>
        private void Resize()
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
        /// Remove value from array in specified index.
        /// </summary>
        /// <param name="index">Index of value, which have to be removed.</param>
        /// <exception cref="IndexOutOfRangeException">Index is negative or index is greater than length.</exception>
        public void Remove(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index of array cannot be negative value.");
            }

            if (index > Length)
            {
                throw new IndexOutOfRangeException("Specified index greater than length of array.");
            }

            for (int i = index; i < _data.Length - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            Length -= 1;
        }
        
        /// <summary>
        /// Checks is there specific element in array.
        /// </summary>
        /// <param name="value">Element to check.</param>
        public bool Contains(T value)
        {
            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i].Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks is there any element in array.
        /// </summary>
        public bool IsEmpty()
        {
            return Length == 0;
        }
        
        /// <summary>
        /// Adds element to the end of array.
        /// </summary>
        public void Add(T value)
        {
            if (Length == _capacity)
            {
                Resize();
            }

            _data[Length] = value;
            Length++;
        }

        /// <summary>
        /// Provide access to element by index.
        /// </summary>
        /// <param name="key">Index of element.</param>
        public T this[int key]
        {
            get => GetValue(key);
            set => SetValue(key, value);
        }
    }
}

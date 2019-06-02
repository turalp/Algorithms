using System;

namespace Algorithms.Algorithms
{
    /// <summary>
    /// Provides static methods of sorting algorithms.
    /// </summary>
    /// <typeparam name="T">Must implement IComparable.</typeparam>
    public static class Sort<T> where T : IComparable<T>
    {
        /// <summary>
        /// Implementation of bubble sorting.
        /// </summary>
        /// <param name="arr">Array that needs to be sorted.</param>
        /// <returns>Sorted array.</returns>
        /// <exception cref="ArgumentNullException">Thrown, when a reference to array is null.</exception>
        public static T[] BubbleSort(T[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) == 1)
                    {
                        T temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            return arr;
        }

        /// <summary>
        /// Implementation of merge sorting.
        /// </summary>
        /// <param name="arr">Array that needs to be sorted.</param>
        /// <returns>Sorted array.</returns>
        /// <exception cref="ArgumentNullException">Thrown, when a reference to array is null.</exception>
        public static T[] MergeSort(T[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            


            T[] Merge(T left, T middle, T right)
            {
                
                return null;
            }

            return arr;
        }
    }
}

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
        public static void BubbleSort(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i].CompareTo(arr[j]) == 1)
                    {

                    }
                }
            }
        }
    }
}

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
        /// <param name="left">Start index.</param>
        /// <param name="right">End index.</param>
        /// <returns>Sorted array.</returns>
        /// <exception cref="ArgumentNullException">Thrown, when a reference to array is null.</exception>
        public static T[] MergeSort(T[] arr, int left, int right)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr));
            }

            if (left < right)
            {
                // Finding middle point
                int middle = (left + right) / 2;

                // sorting two divided parts
                MergeSort(arr, left, middle);
                MergeSort(arr, middle + 1, right);

                // Merging
                Merge(left, middle, right);
            }

            
            void Merge(int l, int m, int r)
            {
                int n1 = m - l + 1;
                int n2 = r - m;

                T[] lTemp = new T[n1];
                T[] rTemp = new T[n2];

                for (int i = 0; i < n1; i++)
                {
                    lTemp[i] = arr[l + i];
                }

                for (int i = 0; i < n2; i++)
                {
                    rTemp[i] = arr[m + 1 + i];
                }

                int f = 0; // index of first subarray
                int s = 0; // index of second subarray

                int k = l; // initial index of merged array

                while (f < n1 && s < n2)
                {
                    if (lTemp[f].CompareTo(rTemp[s]) == -1 || lTemp[f].CompareTo(rTemp[s]) == 0)
                    {
                        arr[k] = lTemp[f];
                        f++;
                    }
                    else
                    {
                        arr[k] = rTemp[s];
                        s++;
                    }

                    k++;
                }

                while (f < n1)
                {
                    arr[k] = lTemp[f];
                    f++;
                    k++;
                }

                while (s < n2)
                {
                    arr[k] = rTemp[s];
                    s++;
                    k++;
                }
            }

            return arr;
        }

        /// <summary>
        /// Provides ability to sort array by quicksort algorithm.
        /// </summary>
        /// <param name="arr">Array than needs to be sorted.</param>
        /// <param name="left">Left index of array (optional).</param>
        /// <param name="right">Right index of array (optional).</param>
        /// <returns>Sorted array.</returns>
        public static T[] QuickSort(T[] arr, int? left = null, int? right = null)
        {
            if (left == null || right == null)
            {
                left = 0;
                right = arr.Length - 1;
            }

            if (left >= right)
            {
                return arr;
            }

            T pivot = arr[(left.Value + right.Value) / 2];

            int index = Partition(arr, left.Value, right.Value, pivot);

            QuickSort(arr, left, index - 1);
            QuickSort(arr, index, right);

            return arr;
        }

        /// <summary>
        /// Internal method for divide array for quicksort algorithm.
        /// </summary>
        /// <param name="arr">Array that needs to be divided.</param>
        /// <param name="left">Start index.</param>
        /// <param name="right">End index.</param>
        /// <param name="pivot">Pivot of array.</param>
        /// <returns>Left index.</returns>
        private static int Partition(T[] arr, int left, int right, T pivot)
        {
            while (left <= right)
            {
                while (arr[left].CompareTo(pivot) == -1)
                {
                    left++;
                }

                while (arr[right].CompareTo(pivot) == 1)
                {
                    right--;
                }

                if (left <= right)
                {
                    Swap(arr, left, right);
                    left++;
                    right--;
                }
            }

            return left;
        }

        /// <summary>
        /// Method for swap two elements in an array.
        /// </summary>
        /// <param name="arr">Array of elements.</param>
        /// <param name="fIndex">Index of first element.</param>
        /// <param name="sIndex">Index of second element.</param>
        private static void Swap(T[] arr, int fIndex, int sIndex)
        {
            T temp = arr[fIndex];
            arr[fIndex] = arr[sIndex];
            arr[sIndex] = temp;
        }
    }
}

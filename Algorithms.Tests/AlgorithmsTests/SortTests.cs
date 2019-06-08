using Algorithms.Algorithms;
using NUnit.Framework;

namespace Algorithms.Tests.AlgorithmsTests
{
    [TestFixture]
    public class SortTests
    {
        [Test]
        public void BubbleSort()
        {
            int[] arr = { 3, 1, 10, 4, 7, 5, 8, 24, 14 };

            Sort<int>.BubbleSort(arr);


            Assert.That(arr[0], Is.EqualTo(1));
            Assert.That(arr[1], Is.EqualTo(3));
            Assert.That(arr[2], Is.EqualTo(4));
            Assert.That(arr[3], Is.EqualTo(5));
            Assert.That(arr[4], Is.EqualTo(7));
            Assert.That(arr[5], Is.EqualTo(8));
            Assert.That(arr[6], Is.EqualTo(10));
            Assert.That(arr[7], Is.EqualTo(14));
            Assert.That(arr[8], Is.EqualTo(24));
        }

        [Test]
        public void MergeSort()
        {
            int[] arr = { 3, 1, 10, 4, 7, 5, 8, 24, 14 };

            Sort<int>.MergeSort(arr, 0, arr.Length - 1);


            Assert.That(arr[0], Is.EqualTo(1));
            Assert.That(arr[1], Is.EqualTo(3));
            Assert.That(arr[2], Is.EqualTo(4));
            Assert.That(arr[3], Is.EqualTo(5));
            Assert.That(arr[4], Is.EqualTo(7));
            Assert.That(arr[5], Is.EqualTo(8));
            Assert.That(arr[6], Is.EqualTo(10));
            Assert.That(arr[7], Is.EqualTo(14));
            Assert.That(arr[8], Is.EqualTo(24));
        }

        [Test]
        public void QuickSort()
        {
            int[] arr = { 3, 1, 10, 4, 7, 5, 8, 24, 14 };

            Sort<int>.QuickSort(arr);


            Assert.That(arr[0], Is.EqualTo(1));
            Assert.That(arr[1], Is.EqualTo(3));
            Assert.That(arr[2], Is.EqualTo(4));
            Assert.That(arr[3], Is.EqualTo(5));
            Assert.That(arr[4], Is.EqualTo(7));
            Assert.That(arr[5], Is.EqualTo(8));
            Assert.That(arr[6], Is.EqualTo(10));
            Assert.That(arr[7], Is.EqualTo(14));
            Assert.That(arr[8], Is.EqualTo(24));
        }
    }
}

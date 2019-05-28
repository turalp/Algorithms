namespace Algorithms
{
    /// <summary>
    /// Data structure that can find max/min by O(logN).
    /// </summary>
    /// <typeparam name="T">Any type.</typeparam>
    public class BinaryHeap<T>
    {
        private static int _capacity;
        private int _size;
        private T[] _data = new T[_capacity];

        /// <summary>
        /// Gets left child of binary heap.
        /// </summary>
        /// <param name="parentIndex">Index of parent element.</param>
        /// <returns>Index of left child.</returns>
        private int GetLeftChildIndex(int parentIndex) => 2 * parentIndex + 1;

        /// <summary>
        /// Gets right child of binary heap.
        /// </summary>
        /// <param name="parentIndex">Index of parent element.</param>
        /// <returns>Index of right child.</returns>
        private int GetRightChildIndex(int parentIndex) => 2 * parentIndex + 2;

        /// <summary>
        /// Gets parent index of binary heap.
        /// </summary>
        /// <param name="childIndex">Index of one of the child element.</param>
        /// <returns>Index of parent element.</returns>
        private int GetParentIndex(int childIndex) => (childIndex - 1) / 2;

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
    }
}

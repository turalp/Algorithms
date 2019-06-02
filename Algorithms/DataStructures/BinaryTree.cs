using System;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Data structure that called binary search tree.
    /// </summary>
    /// <typeparam name="TKey">Key type. Must have CompareTo() method.</typeparam>
    /// <typeparam name="TValue">Any type.</typeparam>
    public class BinaryTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        private Node _root;

        public BinaryTree()
        {
            _root = null;
        }

        /// <summary>
        /// Binary tree search.
        /// </summary>
        /// <param name="key">Key that needs to be found.</param>
        /// <returns>Relevant to key value.</returns>
        public TValue Find(TKey key)
        {
            Node node = Find(_root, key);

            return node == null ? default(TValue) : node.Value;
        }
        
        /// <summary>
        /// Search through tree recursively.
        /// </summary>
        /// <param name="node">Subtree for looking for value.</param>
        /// <param name="key">Key that represents value.</param>
        /// <returns>Relevant node.</returns>
        private Node Find(Node node, TKey key)
        {
            if (node != null && node.Key.Equals(key))
            {
                return node;
            }
            if (key.CompareTo(node.Key) == -1)
            {
                return Find(node.Left, key);
            }
            if (key.CompareTo(node.Key) == 1)
            {
                return Find(node.Right, key);
            }

            return null;
        }

        private Node FindMinimum(Node node)
        {
            return node.Minimum();
        }

        /// <summary>
        /// Inserting item to binary tree.
        /// </summary>
        /// <param name="key">Key of item.</param>
        /// <param name="value">Value of item.</param>
        public void Insert(TKey key, TValue value)
        {
            _root = InsertItem(_root, key, value);
        }

        /// <summary>
        /// Helper recursive method to insert node to specified subtree.
        /// </summary>
        /// <param name="node">Subtree.</param>
        /// <param name="key">Key that needs to be inserted.</param>
        /// <param name="value">Value that needs to be inserted.</param>
        /// <returns></returns>
        private Node InsertItem(Node node, TKey key, TValue value)
        {
            Node newNode = new Node(key, value);

            if (node == null)
            {
                node = newNode;
                return node;
            }

            if (key.CompareTo(node.Key) == -1)
            {
                node.Left = InsertItem(node.Left, key, value);
            }
            else
            {
                node.Right = InsertItem(node.Right, key, value);
            }

            return node;
        }

        /// <summary>
        /// Deletes specified node.
        /// </summary>
        /// <param name="key">Key of node.</param>
        public void Delete(TKey key)
        {
            _root = Delete(_root, key);
        }

        /// <summary>
        /// Helper method to remove specified node.
        /// </summary>
        /// <param name="node">Node that needs to be removed.</param>
        /// <param name="key">Key of node.</param>
        /// <returns>Node to delete.</returns>
        private Node Delete(Node node, TKey key)
        {
            if (node == null)
            {
                return null;
            }

            if (key.CompareTo(node.Key) == -1)
            {
                node.Left = Delete(node.Left, key);
            }
            else if (key.CompareTo(node.Key) == 1)
            {
                node.Right = Delete(node.Right, key);
            }
            else
            {
                if (node.Left == null && node.Right == null) // no child
                {
                    node = null;
                }
                else if (node.Left == null) // one right child
                {
                    node = node.Right;
                }
                else if (node.Right == null) // one left child
                {
                    node = node.Left;
                }
                else // two children
                {
                    Node minNode = FindMinimum(node.Right);

                    node.Key = minNode.Key;
                    node.Value = minNode.Value;

                    node.Right = Delete(node.Right, key);
                }
            }

            return node;
        }

        /// <summary>
        /// Represents node/subtree of BST.
        /// </summary>
        private class Node
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            /// <summary>
            /// Find minimum of given node.
            /// </summary>
            /// <returns>Minimum value in the tree/subtree.</returns>
            public Node Minimum()
            {
                if (Left == null)
                {
                    return this;
                }

                return Left.Minimum();
            }
        }
    }
}

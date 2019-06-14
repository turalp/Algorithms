namespace Algorithms.Tasks
{
    public class SumBinaryTree
    {
        private Node _root;

        public SumBinaryTree()
        {
            _root = null;
        }

        /// <summary>
        /// Inserting item to binary tree.
        /// </summary>
        /// <param name="key">Key of item.</param>
        /// <param name="value">Value of item.</param>
        public void Insert(int key, int value)
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
        private Node InsertItem(Node node, int key, int value)
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
        /// Number of paths, which sum of keys are equal to specified integer.
        /// </summary>
        /// <param name="sum">Specified number, target sum.</param>
        /// <returns></returns>
        public int CountPathToSum(int sum)
        {
            return PathToSum(_root, sum);
        }

        public int PathToSum(Node root, int sum)
        {
            int pathsFromRoot = CalculatePathToSum(root, sum, 0);

            int pathsOnLeft = PathToSum(root, sum);
            int pathsOnRight = PathToSum(root, sum);

            return pathsFromRoot + pathsOnRight + pathsOnLeft;
        }

        public int CalculatePathToSum(Node root, int targetSum, int currentSum)
        {
            currentSum += root.Key;

            int totalPaths = 0;
            if (currentSum == targetSum)
            {
                totalPaths++;
            }

            totalPaths += CalculatePathToSum(root.Left, targetSum, currentSum);
            totalPaths += CalculatePathToSum(root.Right, targetSum, currentSum);

            return totalPaths;
        }

        /// <summary>
        /// Represents node/subtree of BST.
        /// </summary>
        public  class Node
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}

﻿using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        private BinaryTree<int, string> BinaryTree;

        [SetUp]
        public void SetUp()
        {
            BinaryTree = new BinaryTree<int, string>();
        }
    }
}

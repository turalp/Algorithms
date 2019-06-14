using Algorithms.DataStructures;
using Algorithms.Tasks;
using NUnit.Framework;

namespace Algorithms.Tests.Tasks
{
    [TestFixture]
    public class TaskTests
    {
        [Test]
        public void HasUniqueCharacter()
        {
            Assert.That(Task.HasUniqueCharacter("abc"), Is.True);
            Assert.That(Task.HasUniqueCharacter("aa"), Is.False);
            Assert.That(Task.HasUniqueCharacter("abcdefgh"), Is.True);
        }

        [Test]
        public void IsPermutation()
        {
            Assert.That(Task.IsPermutation("abc", "cba"), Is.True);
            Assert.That(Task.IsPermutation("abc", "xyz"), Is.False);
        }

        [Test]
        public void URLify()
        {
            Assert.That(Task.URLify("My Home Page       ", 16), Is.EqualTo("My%20Home%20Page"));
        }

        [Test]
        public void OneAway()
        {
            Assert.That(Task.OneAway("pale", "ple"), Is.True);
            Assert.That(Task.OneAway("pale", "bale"), Is.True);
            Assert.That(Task.OneAway("pale", "pales"), Is.True);
            Assert.That(Task.OneAway("pale", "bla"), Is.False);
        }

        [Test]
        public void Compress()
        {
            Assert.That(Task.Compress("aabbcc"), Is.EqualTo("aabbcc"));
            Assert.That(Task.Compress("aabbbbcc"), Is.EqualTo("a2b4c2"));
            Assert.That(Task.Compress("aaabbbccc"), Is.EqualTo("a3b3c3"));
            Assert.That(Task.Compress("abc"), Is.EqualTo("abc"));
        }

        [Test]
        public void IsSubtree()
        {
            BinaryTree<int, int> tree = new BinaryTree<int, int>();

            tree.Insert(5, 0);
            tree.Insert(3, 1);
            tree.Insert(2, 2);
            tree.Insert(4, 3);
            tree.Insert(7, 4);
            tree.Insert(6, 5);
            tree.Insert(8, 6);

            BinaryTree<int, int> subTree = new BinaryTree<int, int>();

            subTree.Insert(7, 0);
            subTree.Insert(6, 1);
            subTree.Insert(8, 2);

            Assert.That(tree.ToString(), Is.EqualTo("5324768"));
        }
    }
}

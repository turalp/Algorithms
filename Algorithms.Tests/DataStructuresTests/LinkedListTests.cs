using Algorithms.DataStructures;
using NUnit.Framework;

namespace Algorithms.Tests.DataStructuresTests
{
    [TestFixture]
    public class LinkedListTests
    {
        private LinkedList<int> List { get; set; }

        [SetUp]
        public void SetUp()
        {
            List = new LinkedList<int>();
        }

        [Test]
        public void AddFront()
        {
            List.AddFront(0);
            List.AddFront(1);


            Assert.That(List.GetFirst(), Is.EqualTo(1));
            Assert.That(List.GetLast(), Is.EqualTo(0));
        }

        [Test]
        public void GetFirst()
        {
            List.AddFront(0);
            List.AddFront(1);


            Assert.That(List.GetFirst(), Is.EqualTo(1));
        }

        [Test]
        public void GetLast()
        {
            List.AddFront(0);
            List.AddFront(1);


            Assert.That(List.GetLast(), Is.EqualTo(0));
        }

        [Test]
        public void AddBack()
        {
            List.AddBack(0);
            List.AddBack(1);


            Assert.That(List.GetFirst(), Is.EqualTo(0));
            Assert.That(List.GetLast(), Is.EqualTo(1));
        }

        [Test]
        public void Size()
        {
            List.AddFront(0);
            List.AddFront(1);
            List.AddFront(2);
            List.AddFront(3);
            List.AddBack(4);


            Assert.That(List.Size(), Is.EqualTo(5));
        }

        [Test]
        public void Clear()
        {
            List.AddFront(0);
            List.AddFront(1);
            List.AddFront(2);


            List.Clear();


            Assert.That(List.Size(), Is.EqualTo(0));
        }

        [Test]
        public void Delete()
        {
            List.AddBack(0);
            List.AddBack(1);
            List.AddBack(3);
            List.AddBack(2);


            List.Delete(3);


            Assert.That(List.Size(), Is.EqualTo(3));
        }
    }
}

using System;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class QueueTests
    {
        private Queue<int> Queue { get; set; }

        [SetUp]
        public void SetUp()
        {
            Queue = new Queue<int>();
        }

        [Test]
        public void Add()
        {
            Queue.Add(0);
            Queue.Add(1);
            Queue.Add(2);


            Assert.That(Queue.IsEmpty, Is.False);
            Assert.That(Queue.Peek(), Is.EqualTo(0));
        }

        [Test]
        public void Remove()
        {
            Queue.Add(0);
            Queue.Add(1);
            Queue.Add(2);


            Assert.That(Queue.Remove(), Is.EqualTo(0));
        }

        [Test]
        public void Remove_ShouldThrowException()
        {
            Assert.That(() => Queue.Remove(), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void IsEmpty_ShouldReturnFalse()
        {
            Queue.Add(0);

            Assert.That(Queue.IsEmpty(), Is.False);
        }

        [Test]
        public void IsEmpty_ShouldReturnTrue()
        {
            Assert.That(Queue.IsEmpty(), Is.True);
        }

        [Test]
        public void Peek()
        {
            Queue.Add(1);
            Queue.Add(0);


            Assert.That(Queue.Peek(), Is.EqualTo(1));
        }
    }
}

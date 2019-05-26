using System;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<int> Stack { get; set; }

        [SetUp]
        public void SetUp()
        {
            Stack = new Stack<int>();
        }

        [Test]
        public void Push()
        {
            Stack.Push(0);
            Stack.Push(1);
            Stack.Push(2);


            Assert.That(Stack.IsEmpty, Is.False);
            Assert.That(Stack.Peek(), Is.EqualTo(2));
        }

        [Test]
        public void Pop()
        {
            Stack.Push(0);
            Stack.Push(1);
            Stack.Push(2);


            Assert.That(Stack.Pop(), Is.EqualTo(2));
        }

        [Test]
        public void Pop_ShouldThrowException()
        {
            Assert.That(() => Stack.Pop(), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void IsEmpty_ShouldReturnFalse()
        {
            Stack.Push(0);

            Assert.That(Stack.IsEmpty(), Is.False);
        }

        [Test]
        public void IsEmpty_ShouldReturnTrue()
        {
            Assert.That(Stack.IsEmpty(), Is.True);
        }

        [Test]
        public void Peek()
        {
            Stack.Push(1);
            Stack.Push(0);


            Assert.That(Stack.Peek(), Is.EqualTo(0));
        }
    }
}

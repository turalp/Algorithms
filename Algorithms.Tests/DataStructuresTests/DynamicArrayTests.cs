using System;
using Algorithms.DataStructures;
using NUnit.Framework;

namespace Algorithms.Tests.DataStructuresTests
{
    [TestFixture]
    public class DynamicArrayTests
    {
        private DynamicArray<int> _data;

        [SetUp]
        public void SetUp()
        {
            _data = new DynamicArray<int>(4);
        }

        [Test]
        public void GetValue()
        {
            _data.Add(1);
            _data.Add(2);
            _data.Add(3);


            Assert.That(_data[0], Is.EqualTo(1));
            Assert.That(_data[1], Is.EqualTo(2));
            Assert.That(_data[2], Is.EqualTo(3));
        }

        [Test]
        public void GetValue_WhenIndexIsLowerThanNull_ShouldThrowException()
        {
            _data.Add(1);
            _data.Add(2);
            _data.Add(3);

            
            Assert.That(() => _data[-1], Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void GetValue_WhenIndexIsGreaterThanLength_ShouldThrowException()
        {
            _data.Add(1);
            _data.Add(2);
            _data.Add(3);


            Assert.That(() => _data[4], Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void SetValue()
        {
            _data.Add(1);
            _data.Add(3);
            _data.Add(4);


            _data[1] = 2;


            Assert.That(_data[0], Is.EqualTo(1));
            Assert.That(_data[1], Is.EqualTo(2));
            Assert.That(_data[2], Is.EqualTo(3));
            Assert.That(_data[3], Is.EqualTo(4));
        }

        [Test]
        public void SetValue_ShouldIncreaseCapacity()
        {
            _data.Add(1);
            _data.Add(3);
            _data.Add(4);
            _data.Add(5);


            _data[1] = 2;


            Assert.That(_data[0], Is.EqualTo(1));
            Assert.That(_data[1], Is.EqualTo(2));
            Assert.That(_data[2], Is.EqualTo(3));
            Assert.That(_data[3], Is.EqualTo(4));
            Assert.That(_data[4], Is.EqualTo(5));

            Assert.That(_data.Length, Is.EqualTo(5));
        }

        [Test]
        public void SetValue_WhenIndexIsLowerThanNull_ShouldThrowException()
        {
            _data.Add(1);
            _data.Add(2);
            _data.Add(3);


            Assert.That(() => { _data[-1] = 1; }, 
                Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void Remove()
        {
            _data.Add(1);
            _data.Add(2);
            _data.Add(3);


            _data.Remove(1);


            Assert.That(_data[0], Is.EqualTo(1));
            Assert.That(_data[1], Is.EqualTo(3));

            Assert.That(_data.Length, Is.EqualTo(2));
        }

        [Test]
        public void Remove_WhenIndexIsLowerThanNull_ShouldThrowException()
        {
            Assert.That(() => _data.Remove(-1), 
                Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void Remove_WhenIndexIsGreaterThanLength_ShouldThrowException()
        {
            _data.Add(1);


            Assert.That(() => _data.Remove(2),
                Throws.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void Contains()
        {
            _data.Add(1);
            _data.Add(2);
            _data.Add(3);


            Assert.That(_data.Contains(2), Is.True);
            Assert.That(_data.Contains(4), Is.False);
        }

        [Test]
        public void IsEmpty()
        {
            Assert.That(_data.IsEmpty, Is.True);
        }

        [Test]
        public void IsEmpty_ShouldReturnFalse()
        {
            _data.Add(1);
            _data.Add(2);
            _data.Add(3);


            Assert.That(_data.IsEmpty, Is.False);
        }
    }
}

using System;
using System.Diagnostics;
using Algorithms.Algorithms;
using NUnit.Framework;

namespace Algorithms.Tests.AlgorithmsTests
{
    [TestFixture]
    public class FibonacciTests
    {
        [Test]
        public void FibTest()
        {
            Assert.That(Fibonacci.Fib(-1), Is.EqualTo(0));
            Assert.That(Fibonacci.Fib(0), Is.EqualTo(0));
            Assert.That(Fibonacci.Fib(1), Is.EqualTo(1));
            Assert.That(Fibonacci.Fib(3), Is.EqualTo(2));
            Assert.That(Fibonacci.Fib(10), Is.EqualTo(55));
        }

        [Test]
        public void OFibTest()
        {
            Assert.That(Fibonacci.OFib(-1), Is.EqualTo(0));
            Assert.That(Fibonacci.OFib(0), Is.EqualTo(0));
            Assert.That(Fibonacci.OFib(1), Is.EqualTo(1));
            Assert.That(Fibonacci.OFib(3), Is.EqualTo(2));
            Assert.That(Fibonacci.OFib(10), Is.EqualTo(55));
        }

        [Test]
        public void Benchmark()
        {
            Stopwatch watch = new Stopwatch();


            watch.Start();
            Fibonacci.Fib(10);
            watch.Stop();

            TimeSpan fibSpan = watch.Elapsed;

            watch.Restart();
            Fibonacci.OFib(10);
            watch.Stop();

            TimeSpan ofibSpan = watch.Elapsed;


            Assert.That(fibSpan, Is.LessThan(ofibSpan));
        }
    }
}

using System.Collections.Generic;
using NUnit.Framework;

namespace First.Tests
{
    public class FibonacciTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void should_return_the_correct_fibonacci_succession()
        {
            IEnumerable<int> expected = new List<int> {1, 1, 2, 3, 5, 8, 13, 21, 34, 55};
            Assert.AreEqual(expected, Fibonacci.GenerateFibonacci(1, 10));
        }
        
        [Test]
        public void should_return_the_correct_fibonacci_term()
        {
            int expected = 6765;
            Assert.AreEqual(expected, Fibonacci.ComputeFibonacciNumber(20));
        }
    }
}
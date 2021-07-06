using System;
using System.Collections.Generic;
using System.Linq;
using EnumerableExtensions;
using NUnit.Framework;

namespace Linq.Test.Operators
{
    /// <summary>
    /// Use the Take, Skip, TakeWhile and SkipWhile methods to partition the input sequence.
    /// You can get a slice of the input sequence as the output sequence.
    /// </summary>
    [TestFixture]
    public class PartitionOperators
    {
        [Test]
        public void TakeElements()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            IEnumerable<int> first3Numbers = numbers.Take(3);

            Console.WriteLine("First 3 numbers:");
            first3Numbers.ForEach(Console.WriteLine);
        }

        [Test]
        public void TakeWhile()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            IEnumerable<int> firstNumbersLessThan6 =
                numbers.TakeWhile(n => n < 6);
            Console.WriteLine("First numbers less than 6: ");
            firstNumbersLessThan6.ForEach(Console.WriteLine);
        }

        [Test]
        public void TakeWhileWithIndex()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            IEnumerable<int> firstSmallNumbers =
                numbers.TakeWhile((n, index) => n >= index);
            Console.WriteLine("First numbers not less than their position: ");
            firstSmallNumbers.ForEach(Console.WriteLine);
        }

        [Test]
        public void TakeLast()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0, 9};

            // TODO: Solve ambiguous method reference on TakeLast(IEnumerable, int) method
            // int lastNumber = numbers.TakeLast(1).ToList()[0];
            int lastNumber = numbers.AsQueryable().TakeLast(1).ElementAt(0);
            Console.WriteLine("Last number: " + lastNumber);
        }

        [Test]
        public void SkipElements()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            IEnumerable<int> first3Numbers = numbers.Skip(4);

            Console.WriteLine("All but first 4 numbers:");
            first3Numbers.ForEach(Console.WriteLine);
        }

        [Test]
        public void SkipWhile()
        {
            int[] numbers = {5, 9, 1, 4, 9, 8, 6, 7, 2, 0};
            IEnumerable<int> allButFirstOddNumbers =
                numbers.SkipWhile(n => n % 2 != 0);
            Console.WriteLine("All but first odd numbers:");
            allButFirstOddNumbers.ForEach(Console.WriteLine);
        }

        [Test]
        public void SkipWhileWithIndex()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            IEnumerable<int> laterNumbers =
                numbers.SkipWhile((n, index) => n >= index);
            Console.WriteLine(
                "All elements starting from first element less than its position:");
            laterNumbers.ForEach(Console.WriteLine);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using EnumerableExtensions;
using NUnit.Framework;

namespace Linq.Test.Operations
{
    [TestFixture]
    public class SequenceOperations
    {
        [Test]
        public void CompareSequencesForEquality()
        {
            var wordsA = new[] {"cherry", "apple", "blueberry"};
            var wordsB = new[] {"cherry", "apple", "blueberry"};


            bool match = wordsA.SequenceEqual(wordsB);

            Console.WriteLine($"The sequences match: {match}");
        }

        [Test]
        public void ConcatenateSequences()
        {
            int[] numbersA = {0, 2, 4, 5, 6, 8, 9};
            int[] numbersB = {1, 3, 5, 7, 8};

            IEnumerable<int> allNumbers = numbersA.Concat(numbersB);

            Console.WriteLine("All numbers from both arrays:");
            allNumbers.ForEach(n => Console.Write($"{n}, "));
        }
    }
}

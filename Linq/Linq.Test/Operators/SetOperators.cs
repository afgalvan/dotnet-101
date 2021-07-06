using System;
using System.Collections.Generic;
using System.Linq;
using EnumerableExtensions;
using NUnit.Framework;

namespace Linq.Test.Operators
{
    /// <summary>
    /// These operators provide functionality to compare multiple sets of data.
    /// You can find the intersection, union, all distinct elements and the difference between sets.
    /// </summary>
    [TestFixture]
    public class SetOperators
    {
        /// <summary>
        /// This sample uses Distinct to remove duplicate elements in a sequence of factors of 300.
        /// </summary>
        [Test]
        public void FindDistinctElements()
        {
            int[] factorsOf300 = {2, 2, 3, 5, 5};
            IEnumerable<int> uniqueFactors = factorsOf300.Distinct();
            Console.WriteLine("Prime factors of 300:");
            uniqueFactors.ForEach(Console.WriteLine);
        }

        /// <summary>
        /// This sample uses Distinct to find the unique words length.
        /// </summary>
        [Test]
        public void DistinctByProperty()
        {
            string[] words =
            {
                "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese"
            };

            IEnumerable<int> categoryNamesLinq = (from w in words
                select w.Length).Distinct();
            IEnumerable<int> categoryNames =
                words.Select(w => w.Length).Distinct();

            Assert.AreEqual(categoryNamesLinq, categoryNames);
        }

        /// <summary>
        /// This sample uses Union to create one sequence that contains the unique values from both arrays.
        /// </summary>
        [Test]
        public void UnionOfSets()
        {
            int[] numbersA = {0, 2, 4, 1, 6, 8, 9};
            int[] numbersB = {1, 9, 5, 4, 8, 0, 7};

            IEnumerable<int> uniqueNumbers = numbersA.Union(numbersB);

            Console.WriteLine("Unique numbers from both arrays:");
            uniqueNumbers.ForEach(Console.WriteLine);
        }

        [Test]
        public void IntersectionOfSets()
        {
            int[] numbersA = {0, 2, 4, 1, 6, 8, 9};
            int[] numbersB = {1, 9, 5, 4, 8, 0, 7};

            Console.WriteLine("Common numbers from both arrays:");
            IEnumerable<int> commonNumbers = numbersA.Intersect(numbersB);
            commonNumbers.ForEach(Console.WriteLine);
        }

        [Test]
        public void DifferenceOfSets()
        {
            int[] numbersA = {0, 2, 4, 1, 6, 8, 9};
            int[] numbersB = {1, 9, 5, 4, 8, 0};

            Console.WriteLine("Numbers in first array but not second array:");
            IEnumerable<int> commonNumbers = numbersA.Except(numbersB);
            commonNumbers.ForEach(Console.WriteLine);
        }
    }
}

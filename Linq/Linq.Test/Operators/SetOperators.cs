using System;
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
            int[] factorsOf300 = { 2, 2, 3, 5, 5 };
            var uniqueFactors = factorsOf300.Distinct();
            Console.WriteLine("Prime factors of 300:");
            uniqueFactors.ForEach(Console.WriteLine);
        }
    }
}
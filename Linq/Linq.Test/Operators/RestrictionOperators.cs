using System;
using System.Collections.Generic;
using System.Linq;
using EnumerableExtensions;
using NUnit.Framework;

namespace Linq.Test.Operators
{
    [TestFixture]
    public class RestrictionOperators
    {
        /// <summary>
        /// Where keyword works as a Filter.
        /// The where keyword or Where method provide this capability.
        /// These operators restrict, or filter, the input sequence to produce an output sequence.
        /// </summary>
        [Test]
        public void WhereKeyword()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            // Linq Style
            IEnumerable<int> lowNumsLinq = from num in numbers
                where num < 5
                select num;

            IEnumerable<int> lowNums = numbers.Where(n => n < 5);

            Assert.AreEqual(lowNumsLinq, lowNums);
            Console.WriteLine("Numbers < 5:");
            lowNums.ForEach(Console.WriteLine);
        }

        [Test]
        public void WhereKeywordWithIndex()
        {
            string[] digits = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

            IEnumerable<string> shortDigits = digits.Where((digit, index) => digit.Length < index);

            Console.WriteLine("Short digits:");
            shortDigits.ForEach(d => Console.WriteLine($"The word {d} is shorter than its value."));
        }
    }
}
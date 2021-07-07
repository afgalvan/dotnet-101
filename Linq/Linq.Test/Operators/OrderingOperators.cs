using System;
using System.Collections.Generic;
using System.Linq;
using EnumerableExtensions;
using NUnit.Framework;

namespace Linq.Test.Operators
{
    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        }
    }

    /// <summary>
    /// The orderby keyword, along with descending, and the OrderBy, ThenBy, OrderByDescending
    /// and ThenByDescending LINQ queries are used to sort data output.
    /// </summary>
    [TestFixture]
    public class OrderingOperators
    {
        [Test]
        public void OrderElements()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            IOrderedEnumerable<string> orderedWordsLinq = from word in words
                orderby word
                select word;
            IOrderedEnumerable<string> orderedWords = words.OrderBy(w => w);
            Assert.AreEqual(orderedWordsLinq, orderedWords);

            Console.WriteLine("The ordered list of words: ");
            orderedWords.ForEach(w => Console.WriteLine(w));
        }

        [Test]
        public void OrderByProperty()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            IOrderedEnumerable<string> orderedWordsLinq = from word in words
                orderby word.Length
                select word;
            IOrderedEnumerable<string> orderedWords =
                words.OrderBy(w => w.Length);
            Assert.AreEqual(orderedWordsLinq, orderedWords);

            Console.WriteLine("The ordered list of words: ");
            orderedWords.ForEach(w => Console.WriteLine(w));
        }

        [Test]
        public void OrderDescending()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            IOrderedEnumerable<string> orderedWordsLinq = from word in words
                orderby word descending
                select word;
            IOrderedEnumerable<string> orderedWords =
                words.OrderByDescending(w => w);
            Assert.AreEqual(orderedWordsLinq, orderedWords);

            Console.WriteLine("The ordered list of words: ");
            orderedWords.ForEach(w => Console.WriteLine(w));
        }

        [Test]
        public void OrderFromMultipleProperties()
        {
            string[] digits =
            {
                "zero", "one", "two", "three", "four", "five", "six", "seven",
                "eight", "nine"
            };

            IOrderedEnumerable<string> orderedByTwoParametersLinq =
                from digit in digits
                orderby digit.Length, digit
                select digit;
            IOrderedEnumerable<string> orderedByTwoParameters = digits
                .OrderBy(digit => digit.Length)
                .ThenBy(digit => digit);

            Assert.AreEqual(orderedByTwoParametersLinq, orderedByTwoParameters);

            Console.WriteLine("Ordered digits:");
            orderedByTwoParameters.ForEach(digit => Console.WriteLine(digit));
        }

        [Test]
        public void ReverseSequence()
        {
            string[] digits =
            {
                "zero", "one", "two", "three", "four", "five", "six", "seven",
                "eight", "nine"
            };
            IEnumerable<string> reversedIDigitsLinq = (
                from digit in digits
                where digit[1] == 'i'
                select digit
            ).Reverse();
            IEnumerable<string> reversedIDigits =
                digits.Where(digit => digit[1] == 'i').Reverse();
            Assert.AreEqual(reversedIDigitsLinq, reversedIDigits);
            Console.WriteLine(
                "A backwards list of the digits with a second character of 'i':");
            reversedIDigits.ForEach(digit => Console.WriteLine(digit));
        }

        [Test]
        public void OrderByWithCustomComparer()
        {
            string[] words =
                {"aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"};

            IOrderedEnumerable<string> sortedWords =
                words.OrderBy(w => w, new CaseInsensitiveComparer());
            sortedWords.ToList().ForEach(Console.WriteLine);
        }
    }
}

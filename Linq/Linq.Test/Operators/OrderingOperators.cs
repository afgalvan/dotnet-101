using System;
using System.Collections.Generic;
using System.Linq;
using EnumerableExtensions;
using NUnit.Framework;

namespace Linq.Test.Operators
{
    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y) =>
            string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
    }
    
    [TestFixture]
    public class OrderingOperators
    {
        [Test]
        public void OrderElements()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            var orderedWordsLinq = from word in words
                orderby word
                select word;
            var orderedWords = words.OrderBy(w => w);
            Assert.AreEqual(orderedWordsLinq, orderedWords);

            Console.WriteLine("The ordered list of words: ");
            orderedWords.ForEach(w => Console.WriteLine(w));
        }

        [Test]
        public void OrderByProperty()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            var orderedWordsLinq = from word in words
                orderby word.Length
                select word;
            var orderedWords = words.OrderBy(w => w.Length);
            Assert.AreEqual(orderedWordsLinq, orderedWords);

            Console.WriteLine("The ordered list of words: ");
            orderedWords.ForEach(w => Console.WriteLine(w));
        }

        [Test]
        public void OrderDescending()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            var orderedWordsLinq = from word in words
                orderby word descending
                select word;
            var orderedWords = words.OrderByDescending(w => w);
            Assert.AreEqual(orderedWordsLinq, orderedWords);

            Console.WriteLine("The ordered list of words: ");
            orderedWords.ForEach(w => Console.WriteLine(w));
        }

        [Test]
        public void OrderFromMultipleProperties()
        {
            string[] digits = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

            var orderedByTwoParametersLinq = from digit in digits
                orderby digit.Length, digit
                select digit;
            var orderedByTwoParameters = digits.OrderBy(digit => digit.Length)
                .ThenBy(digit => digit);

            Assert.AreEqual(orderedByTwoParametersLinq, orderedByTwoParameters);

            Console.WriteLine("Ordered digits:");
            orderedByTwoParameters.ForEach(digit => Console.WriteLine(digit));
        }

        [Test]
        public void ReverseSequence()
        {
            string[] digits = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
            var reversedIDigitsLinq = (
                from digit in digits
                where digit[1] == 'i'
                select digit
            ).Reverse();
            var reversedIDigits = digits.Where(digit => digit[1] == 'i').Reverse();
            Assert.AreEqual(reversedIDigitsLinq, reversedIDigits);
            Console.WriteLine("A backwards list of the digits with a second character of 'i':");
            reversedIDigits.ForEach(digit => Console.WriteLine(digit));
        }

        [Test]
        public void OrderByWithCustomComparer()
        {
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = words.OrderBy(w => w, new CaseInsensitiveComparer());
            sortedWords.ToList().ForEach(Console.WriteLine);
        }
    }
}
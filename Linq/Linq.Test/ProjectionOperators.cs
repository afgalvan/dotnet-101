using System;
using System.Collections.Generic;
using System.Linq;
using EnumerableExtensions;
using NUnit.Framework;

namespace Linq.Test
{
    [TestFixture]
    public class ProjectionOperators
    {
        [Test]
        public void SelectClause()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            Console.WriteLine("Original Numbers: ");
            numbers.ForEach(n => Console.Write($"{n}, "));
            IEnumerable<int> numsPlusOne = numbers.Select(x => x + 1);

            Console.WriteLine("\nNumbers + 1:");
            numsPlusOne.ForEach(n => Console.Write($"{n}, "));
        }

        [Test]
        public void TransformWithSelectClause()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            string[] strings = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

            IEnumerable<string> textNums = numbers.Select(n => strings[n]);

            Console.WriteLine("Number strings:");
            textNums.ForEach(t => Console.Write($"{t}, "));
        }

        [Test]
        public void TransformToTuples()
        {
            string[] words = {"aPPLE", "BlUeBeRrY", "cHeRry"};

            // Using an anonymous object
            // var upperLowerWords = words.Select(w => new {Upper = w.ToUpper(), Lower = w.ToLower()});

            // Using a tuple
            var upperLowerWords = words.Select(w => (Upper: w.ToUpper(), Lower: w.ToLower()));
            upperLowerWords.ForEach(ul => Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}"));
        }

        [Test]
        public void SelectToCreateNewTypes()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            string[] strings = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

            var digitOddEvens = from n in numbers
                select new {Digit = strings[n], Even = n % 2 == 0};

            digitOddEvens.ForEach(d =>
                Console.WriteLine($"The digit {d.Digit} is {(d.Even ? "even" : "odd")}.")
            );
        }
    }
}
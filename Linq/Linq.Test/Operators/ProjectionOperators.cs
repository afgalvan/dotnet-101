using System;
using System.Collections.Generic;
using System.Linq;
using EnumerableExtensions;
using NUnit.Framework;

namespace Linq.Test.Operators
{
    [TestFixture]
    public class ProjectionOperators
    {
        /// <summary>
        /// Select works as a Map method.
        /// The select keyword or Select method provide this capability.
        /// These operators create output sequence elements from input sequence elements.
        /// The output elements may be either the same or different types.
        /// </summary>
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
            string[] strings =
            {
                "zero", "one", "two", "three", "four", "five", "six", "seven",
                "eight", "nine"
            };

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
            IEnumerable<(string Upper, string Lower)> upperLowerWords =
                words.Select(w => (Upper: w.ToUpper(), Lower: w.ToLower()));
            upperLowerWords.ForEach(ul =>
                Console.WriteLine(
                    $"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}"));
        }

        [Test]
        public void SelectToCreateNewTypes()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            string[] strings =
            {
                "zero", "one", "two", "three", "four", "five", "six", "seven",
                "eight", "nine"
            };

            var digitOddEvens = from n in numbers
                select new {Digit = strings[n], Even = n % 2 == 0};

            digitOddEvens.ForEach(d =>
                Console.WriteLine(
                    $"The digit {d.Digit} is {(d.Even ? "even" : "odd")}.")
            );
        }

        [Test]
        public void SelectWithIndex()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            IEnumerable<(int Num, bool InPlace)> numsInPlace =
                numbers.Select((n, index) => (Num: n, InPlace: n == index));
            Console.WriteLine("Number: In-Place?");
            numsInPlace.ForEach(n =>
                Console.WriteLine($"{n.Num}:\t\t{n.InPlace}"));
        }

        [Test]
        public void SelectWithWhere()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            string[] digits =
            {
                "zero", "one", "two", "three", "four", "five", "six", "seven",
                "eight", "nine"
            };

            IEnumerable<string> lowNums = numbers.Where(n => n < 5)
                .Select(n => digits[n]);

            Console.WriteLine("Numbers < 5: ");
            lowNums.ForEach(n => Console.WriteLine(n));
        }

        [Test]
        public void ProjectionWithMultipleInputs()
        {
            int[] numbersA = {0, 2, 4, 5, 6, 8, 9};
            int[] numbersB = {1, 3, 5, 7, 8};

            IEnumerable<(int a, int b)> pairs = from a in numbersA
                from b in numbersB
                where a < b
                select (a, b);

            IEnumerable<(int a, int b)> otherPairs = numbersA.SelectMany(
                a => numbersB.Where(b => a < b)
                    .Select(b => (a, b))
            );

            Assert.AreEqual(pairs, otherPairs);
            pairs.ForEach(pair =>
                Console.WriteLine($"{pair.a} is less than {pair.b}"));
        }
    }
}

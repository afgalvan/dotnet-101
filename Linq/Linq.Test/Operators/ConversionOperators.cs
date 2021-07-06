using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using EnumerableExtensions;

namespace Linq.Test.Operators
{
    /// <summary>
    /// Sometimes you want to convert a query result set to a different kind of collection.
    /// These operators show how you can do this.
    /// </summary>
    [TestFixture]
    public class ConversionOperators
    {
        [Test]
        public void ConvertToArray()
        {
            double[] doubles = {1.7, 2.3, 1.9, 4.1, 2.9};

            IOrderedEnumerable<double> sortedDoublesLinq = from d in doubles
                orderby d descending
                select d;
            IOrderedEnumerable<double> sortedDoubles =
                doubles.OrderByDescending(d => d);
            double[] doublesArray = sortedDoubles.ToArray();

            Assert.AreEqual(sortedDoublesLinq, sortedDoubles);

            Console.WriteLine("Every other double from highest to lowest:");
            for (var i = 0; i < doubles.Length; i += 2)
                Console.WriteLine(doublesArray[i]);
        }

        [Test]
        public void ConvertToList()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            IOrderedEnumerable<string> orderedWordsLinq = from w in words
                orderby w
                select w;
            IOrderedEnumerable<string> orderedWords = words.OrderBy(w => w);

            Assert.AreEqual(orderedWordsLinq, orderedWords);

            Console.WriteLine("The sorted word list:");
            orderedWords.ToList().ForEach(Console.WriteLine);
        }

        [Test]
        public void ConvertToDictionary()
        {
            var scoreRecords = new[]
            {
                new {Name = "Alice", Score = 50},
                new {Name = "Bob", Score = 40},
                new {Name = "Cathy", Score = 45}
            };

            var scoreRecordsDict = scoreRecords.ToDictionary(sr => sr.Name);
            Console.WriteLine("Bob's data: {0}", scoreRecordsDict["Bob"]);
        }

        [Test]
        public void ConvertToMatchedType()
        {
            object[] numbers = {null, 1.0, "two", 3, "four", 5, "six", 7.0};

            IEnumerable<double> doubles = numbers.OfType<double>();

            Console.WriteLine("Numbers stored as doubles:");
            doubles.ForEach(Console.WriteLine);
        }
    }
}

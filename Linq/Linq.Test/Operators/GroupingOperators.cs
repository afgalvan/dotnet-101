using System;
using System.Collections.Generic;
using System.Linq;
using EnumerableExtensions;
using NUnit.Framework;

namespace Linq.Test.Operators
{
    /// <summary>
    /// The GroupBy and into operators organize a sequence into buckets.
    /// </summary>
    [TestFixture]
    public class GroupingOperators
    {
        public class AnagramEqualityComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y) => GetCanonicalString(x) == GetCanonicalString(y);

            public int GetHashCode(string obj) => GetCanonicalString(obj).GetHashCode();

            private static string GetCanonicalString(string word)
            {
                char[] wordChars = word.ToCharArray();
                Array.Sort(wordChars);
                return new string(wordChars);
            }
        }
        
        [Test]
        public void GroupByIntoBuckets()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            var numberGroupLinq = from n in numbers
                group n by n % 5
                into g
                select (Remainder: g.Key, Numbers: g);
            var numberGroup = numbers.GroupBy(n => n % 5)
                .Select(g => (Remainder: g.Key, Numbers: g));
            
            Assert.AreEqual(numberGroupLinq, numberGroup);
            numberGroup.ForEach(g =>
            {
                var (remainder, grouping) = g;
                Console.WriteLine($"\nNumbers with a remainder of {remainder} when divided by 5:");
                grouping.ForEach(n => Console.Write($"{n}, "));
            });
        }

        [Test]
        public void GroupByUsingProperties()
        {
            string[] words = { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" };

            var wordGroupsLinq = from w in words
                group w by w[0] into g
                select (FirstLetter: g.Key, Words: g);
            var wordGroups = words.GroupBy(w => w[0])
                .Select(g => (FirstLetter: g.Key, Words: g));

            Assert.AreEqual(wordGroupsLinq, wordGroups);
            wordGroups.ForEach(g =>
            {
                var (firstLetter, words) = g;
                Console.WriteLine("\nWords that start with the letter '{0}':", firstLetter);
                words.ForEach(word => Console.Write($"{word}, "));
            });
        }
        
        [Test]
        public void GroupByWithCustomComparer()
        {
            string[] anagrams = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };
            var orderGroups = anagrams.GroupBy(
                w => w.Trim(),
                a => a.ToUpper().Trim(),
                new AnagramEqualityComparer());
            orderGroups.ForEach(set =>
            {
                Console.WriteLine(set.Key);
                set.ForEach(word => Console.WriteLine($"\t{word}"));
            });
        }
    }
}
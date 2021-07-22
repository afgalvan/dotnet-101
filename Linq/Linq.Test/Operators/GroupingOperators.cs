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
        private class AnagramEqualityComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return GetCanonicalString(x) == GetCanonicalString(y);
            }

            public int GetHashCode(string obj)
            {
                return GetCanonicalString(obj).GetHashCode();
            }

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
            IEnumerable<(int Remainder, IGrouping<int, int> Numbers)>
                numberGroupLinq = from n in numbers
                    group n by n % 5
                    into g
                    select (Remainder: g.Key, Numbers: g);

            IEnumerable<(int Remainder, IGrouping<int, int> Numbers)>
                numberGroup = numbers.GroupBy(n => n % 5)
                    .Select(g => (Remainder: g.Key, Numbers: g));

            Assert.AreEqual(numberGroupLinq, numberGroup);
            numberGroup.ForEach(g =>
            {
                (int remainder, IGrouping<int, int> grouping) = g;
                Console.WriteLine(
                    $"\nNumbers with a remainder of {remainder} when divided by 5:");
                grouping.ForEach(n => Console.Write($"{n}, "));
            });
        }

        [Test]
        public void GetUniquesRepeatLetter()
        {
            char[] letters = {'a', 'b', 'k', 'j', 'b', 'a', 'h'};
            letters.GroupBy(letter => letter)
                .Where(group => group.Count() == 1)
                .Select(group => group.Key)
                .ForEach(Console.WriteLine);
        }

        [Test]
        public void GroupByUsingProperties()
        {
            string[] words =
            {
                "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese"
            };

            IEnumerable<(char FirstLetter, IGrouping<char, string> Words)>
                wordGroupsLinq = from w in words
                    group w by w[0]
                    into g
                    select (FirstLetter: g.Key, Words: g);
            IEnumerable<(char FirstLetter, IGrouping<char, string> Words, int
                Count)> wordGroups = words.GroupBy(w => w[0])
                .Select(g => (FirstLetter: g.Key, Words: g, Count: g.Count()));

            Assert.AreEqual(wordGroupsLinq, wordGroups);
            wordGroups.ForEach(g =>
            {
                (char firstLetter, IGrouping<char, string> grouping, _) = g;
                Console.WriteLine("\nWords that start with the letter '{0}':",
                    firstLetter);
                grouping.ForEach(word => Console.Write($"{word}, "));
            });
        }

        [Test]
        public void GroupByWithCustomComparer()
        {
            string[] anagrams =
            {
                "from   ", " salt", " earn ", "  last   ", " near ", " form  "
            };
            IEnumerable<IGrouping<string, string>> orderGroups =
                anagrams.GroupBy(
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

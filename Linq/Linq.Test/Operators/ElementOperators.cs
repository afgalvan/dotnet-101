using NUnit.Framework;
using System;
using System.Linq;

namespace Linq.Test.Operators
{
    /// <summary>
    /// The methods First, FirstOrDefault, Last, LastOrDefault, and ElementAt retrieve elements based
    /// on the position of that element in the sequence.
    /// </summary>
    [TestFixture]
    public class ElementOperators
    {
        [Test]
        public void FindFirstMatchingElement()
        {
            string[] strings =
            {
                "zero", "one", "two", "three", "four", "five", "six",
                "seven", "eight", "nine"
            };

            string startsWithO = strings.First(s => s[0] == 'o');

            Console.WriteLine($"A string starting with 'o': {startsWithO}");
        }

        /// <summary>
        ///
        /// </summary>
        [Test]
        public void FindOrDefaultMatchingElement()
        {
            string[] numbers =
            {
                "zero", "one", "two", "three", "four", "five", "six",
                "seven", "eight", "nine", "ten"
            };

            string firstLongWord = numbers.FirstOrDefault(n => n.Length > 10);
            Console.WriteLine("Fist word with length more than 10: ");
            Console.WriteLine(firstLongWord);
        }

        /// <summary>
        /// This sample uses ElementAt to retrieve the second number greater than 5 from an array.
        /// </summary>
        [Test]
        public void GetElementAtPosition()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            int fourthLowNum = numbers.Where(n => n > 5).ElementAt(1);

            Console.WriteLine($"Second number > 5: {fourthLowNum}");
        }
    }
}

using NUnit.Framework;
using System;
using System.Linq;

namespace Linq.Test.Quantifying
{
    [TestFixture]
    public class QuantifyingMembers
    {
        [Test]
        public void CheckForAnyMatch()
        {
            string[] words = {"believe", "relief", "receipt", "field"};

            bool iAfterE = words.Any(w => w.Contains("ei"));

            Assert.True(iAfterE);
            Console.WriteLine(
                $"There is a word that contains in the list that contains 'ei': {iAfterE}");
        }

        [Test]
        public void CheckForAllMatch()
        {
            int[] numbers = {1, 11, 3, 19, 41, 65, 19};

            bool onlyOdd = numbers.All(n => n % 2 == 1);
            Assert.True(onlyOdd);
            Console.WriteLine($"The list contains only odd numbers: {onlyOdd}");
        }
    }
}

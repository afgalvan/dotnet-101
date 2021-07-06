using System;
using System.Linq;
using NUnit.Framework;

namespace Linq.Test.Operators
{
    /// <summary>
    /// There are a number of methods that perform calculations on values in a sequence.
    /// Note that some of these methods require that the input sequence is a numeric type.
    /// </summary>
    [TestFixture]
    public class AggregatorOperator
    {
        [Test]
        public void CountElements()
        {
            int[] factorsOf300 = {2, 2, 3, 5, 5};

            int uniqueFactors = factorsOf300.Distinct().Count();
            Console.WriteLine(
                $"There are {uniqueFactors} unique factors of 300.");
        }

        [Test]
        public void CountARestriction()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            //                                  Restriction
            int oddNumbers = numbers.Count(n => n % 2 == 1);

            Console.WriteLine("There are {0} odd numbers in the list.",
                oddNumbers);
        }

        [Test]
        public void SumElements()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            double numSum = numbers.Sum();

            Console.WriteLine($"The sum of the numbers is {numSum}");
        }

        [Test]
        public void SumAProjection()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            //                             Projection
            double totalChars = words.Sum(w => w.Length);

            Console.WriteLine(
                $"There are a total of {totalChars} characters in these words.");
        }
    }
}

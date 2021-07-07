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

        [Test]
        public void FindMinimumOfASequence()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            int minNum = numbers.Min();

            Console.WriteLine($"The minimum number is {minNum}");
        }

        [Test]
        public void FindMinimumOfAProjection()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            int shortestWord = words.Min(w => w.Length);

            Console.WriteLine(
                $"The shortest word is {shortestWord} characters long.");
        }

        [Test]
        public void FindMaximumOfASequence()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            int maxNum = numbers.Max();

            Console.WriteLine($"The maximum number is {maxNum}");
        }

        [Test]
        public void FindMaximumOfAProjection()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            int longestLength = words.Max(w => w.Length);

            Console.WriteLine(
                $"The longest word is {longestLength} characters long.");
        }

        [Test]
        public void AverageOfSequence()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            double averageNum = numbers.Average();

            Console.WriteLine($"The average number is {averageNum}.");
        }

        [Test]
        public void AverageOfAProjection()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            double averageLength = words.Average(w => w.Length);

            Console.WriteLine(
                $"The average word length is {averageLength} characters.");
        }

        /// <summary>
        /// Works as a reduce method.
        /// This sample uses Aggregate to create a running product on the array
        /// that calculates the total product of all elements.
        /// </summary>
        [Test]
        public void AggregateMethod()
        {
            double[] doubles = {1.7, 2.3, 1.9, 4.1, 2.9};

            double product =
                doubles.Aggregate((current, next) => current * next);

            Console.WriteLine($"Total product of all numbers: {product}");
        }

        [Test]
        public void AggregateMethodWithSeed()
        {
            var startBalance = 100.0;

            int[] attemptedWithdrawals = {20, 10, 40, 50, 10, 70, 30};

            double endBalance = attemptedWithdrawals.Aggregate(
                startBalance,
                (balance, nextWithdrawal) =>
                    nextWithdrawal <= balance ? balance - nextWithdrawal : balance);

            Console.WriteLine($"Ending balance: {endBalance}");
        }

        [Test]
        public void AggregateToFindLongestWord()
        {
            string[] words = {"cherry", "apple", "blueberry"};

            string longestWord = words.Aggregate("",
                (current, next) =>
                    next.Length > current.Length ? next : current);

            Console.WriteLine($"The longest word is: {longestWord}");
        }
    }
}

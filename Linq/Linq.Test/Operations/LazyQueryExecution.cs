using System;
using System.Collections.Generic;
using System.Linq;
using EnumerableExtensions;
using NUnit.Framework;

namespace Linq.Test.Operations
{
    [TestFixture]
    public class LazyQueryExecution
    {
        [Test]
        public void QueriesExecutedLazily()
        {
            // Sequence operators form first-class queries that
            // are not executed until you enumerate over them.

            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            var i = 0;
            IEnumerable<int> q = numbers.Select(n => ++i);

            // Note, the local variable 'i' is not incremented
            // until each element is evaluated (as a side-effect):
            q.ForEach(v => Console.WriteLine($"v = {v}, i = {i}"));
        }

        [Test]
        public void EagerExecution()
        {
            // Methods like ToList() cause the query to be
            // executed immediately, caching the results.

            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            var i = 0;
            List<int> q = numbers.Select(n => ++i).ToList();

            // The local variable i has already been fully
            // incremented before we iterate the results:

            // Note, the local variable 'i' is not incremented
            // until each element is evaluated (as a side-effect):
            q.ForEach(v => Console.WriteLine($"v = {v}, i = {i}"));
        }

        [Test]
        public void ReuseQueryWithNewData()
        {
            // Deferred execution lets us define a query once
            // and then reuse it later after data changes.

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            IEnumerable<int> lowNumbers = numbers.Where(n => n <= 3);

            // 1, 3, 2, 0
            Console.WriteLine("First run numbers <= 3:");
            lowNumbers.ForEach(n=> Console.Write($"{n}, "));

            for (var i = 0; i < 10; i++)
            {
                numbers[i] = -numbers[i];
            }

            // During this second run, the same query object,
            // lowNumbers, will be iterating over the new state
            // of numbers[], producing different results:
            // -5, -4, -1, -3, -9, -8, -6, -7, -2, 0
            Console.WriteLine("\nSecond run numbers <= 3:");
            lowNumbers.ForEach(n=> Console.Write($"{n}, "));
        }
    }
}

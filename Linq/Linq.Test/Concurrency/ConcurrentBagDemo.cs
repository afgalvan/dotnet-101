using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Linq.Test.Concurrency
{
    [TestFixture]
    internal class ConcurrentBagDemo
    {
        // Demonstrates:
        //      ConcurrentBag<T>.Add()
        //      ConcurrentBag<T>.IsEmpty
        //      ConcurrentBag<T>.TryTake()
        //      ConcurrentBag<T>.TryPeek()
        [Test]
        public void ConcurrentBag()
        {
            // Add to ConcurrentBag concurrently
            var concurrentBag = new ConcurrentBag<int>();
            var bagAddTasks = new List<Task>();
            for (var i = 0; i < 5; i++)
            {
                int numberToAdd = i;
                bagAddTasks.Add(Task.Run(() => concurrentBag.Add(numberToAdd)));
            }

            // Wait for all tasks to complete
            Task.WaitAll(bagAddTasks.ToArray());

            // Consume the items in the bag
            var bagConsumeTasks = new List<Task>();
            var itemsInBag = 0;
            while (!concurrentBag.IsEmpty)
                bagConsumeTasks.Add(Task.Run(() =>
                {
                    if (!concurrentBag.TryTake(out int item)) return;

                    Console.WriteLine(item);
                    itemsInBag++;
                }));

            Task.WaitAll(bagConsumeTasks.ToArray());

            Console.WriteLine($"There were {itemsInBag} items in the bag");

            if (concurrentBag.TryPeek(out _))
                Console.WriteLine(
                    "Found an item in the bag when it should be empty");
        }
    }
}

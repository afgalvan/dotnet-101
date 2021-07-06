using NUnit.Framework;
using System;
using System.Linq;
using EnumerableExtensions;

namespace Linq.Test.Generation
{
    [TestFixture]
    public class GenerateSequences
    {
        [Test]
        public void CreateRangeOfNumbers() =>
            Enumerable.Range(100, 50)
                .Select(n => (Number: n, OddEven: n % 2 == 0 ? "even" : "odd"))
                .ForEach(n => Console.WriteLine("The number {0} is {1}.",
                    n.Number, n.OddEven));

        [Test]
        public void RepeatNumber()
        {
            var numbers = Enumerable.Repeat(7, 10);
            numbers.ForEach(Console.WriteLine);
        }
    }
}

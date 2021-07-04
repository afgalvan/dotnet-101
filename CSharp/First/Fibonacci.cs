using System;
using System.Collections.Generic;
using System.Linq;

namespace First
{
    public static class Fibonacci
    {
        private static void Main()
        {
            IEnumerable<int> succession = GenerateFibonacci(1, 20);
            foreach (int n in succession)
            {
                Console.Write(n + ", ");
            }
        }

        public static IEnumerable<int> GenerateFibonacci(int start, int count) =>
            Enumerable.Range(start, count).Select(ComputeFibonacciNumber);

        public static int ComputeFibonacciNumber(int index) => (int)((1 / Math.Sqrt(5)) *
                                                                     (Math.Pow(((1 + Math.Sqrt(5)) / 2), index) -
                                                                      Math.Pow(((1 - Math.Sqrt(5)) / 2), index)));
    }
}
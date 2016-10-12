using System;
using System.Linq;

namespace Chapter1
{
    public static class ParallelQuerySequential
    {
        public static void Start()
        {
            var numbers = Enumerable.Range(1, 20);

            var parallelResult = numbers.AsParallel().AsOrdered().Where(i => i % 2 == 0).AsSequential();

            foreach(int i in parallelResult.Take(5))
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}

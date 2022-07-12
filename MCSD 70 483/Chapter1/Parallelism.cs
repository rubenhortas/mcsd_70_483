using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class Parallelism
    {
        // For small works sets or for work that has to syncrhonize access to resources using the Parallel class 
        // can hurt performance.
        public static void Start()
        {
            Console.WriteLine("Parallel For");

            Parallel.For(0, 10, i =>
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            });

            Console.WriteLine("Parallel Foreach");

            var numbers = Enumerable.Range(0, 10);

            Parallel.ForEach(numbers, i =>
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            });

            // You can cancel the loop by using the ParallelLoopState object
            Console.WriteLine("Parallel break");

            ParallelLoopResult breakResult = Parallel.For(0, 1000, (int i, ParallelLoopState loopState) =>
            {
                if (i == 500)
                {
                    Console.WriteLine("Breaking Loop");
                    loopState.Break();
                }
                return;
            });

            Console.WriteLine(String.Concat("IsCompleted: ", breakResult.IsCompleted));
            Console.WriteLine(String.Concat("LowestBreakIteration: ", breakResult.LowestBreakIteration));

            ParallelLoopResult stopResult = Parallel.For(0, 1000, (int i, ParallelLoopState loopState) =>
            {
                if (i == 500)
                {
                    Console.WriteLine("Stopping Loop");
                    loopState.Stop();
                }
                return;
            });

            Console.WriteLine(String.Concat("IsCompleted: ", stopResult.IsCompleted));
            Console.WriteLine(String.Concat("LowestBreakIteration: ", stopResult.LowestBreakIteration));
        }
    }
}

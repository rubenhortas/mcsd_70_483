using System;
using System.Linq;

namespace Chapter1
{
    // Disable "Jut my Code" to prevent Visual Studio breaks with "exception not handled by user code"
    // This error is benign. You can press F5 to continue from it.
    // Tools > Options > Debugging > General
    public static class CatchingAggregateExceptions
    {
        public static void Start()
        {

            var numbers = Enumerable.Range(0, 20);

            try
            {
                var parallelResult = numbers.AsParallel().Where(i => IsEven(i));

                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("There where {0} exceptions", e.InnerExceptions.Count());
            }
        }

        private static bool IsEven(int i)
        {
            if (i % 10 == 0)
            {
                throw new ArgumentException("exception");
            }

            return (i % 2 == 0);
        }
    }
}

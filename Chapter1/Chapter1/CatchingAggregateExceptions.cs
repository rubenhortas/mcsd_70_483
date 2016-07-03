using System;
using System.Linq;

namespace Chapter1
{
    public static class CatchingAggregateExceptions
    {
        public static void Start()
        {

            var numbers = Enumerable.Range(0, 50);

            try
            {
                var parallelResult = numbers.AsParallel().Where(i => IsEven(i));

                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch (AggregateException e)
            {
                Console.WriteLine("There where {0} exceptions", e.InnerExceptions.Count());
            }

            Console.ReadLine();
        }

        private static bool IsEven(int i)
        {
            if (i % 10 == 0)
            {
                throw new ArgumentException("i");
            }
            
            return (i % 2 == 0);
        }
    }
}

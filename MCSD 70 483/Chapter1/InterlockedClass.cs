using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class InterlockedClass
    {
        public static void Start()
        {
            int n = 0;

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Interlocked.Increment(ref n);
                }
            });

            var down = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    Interlocked.Decrement(ref n);
                }
            });

            up.Wait();

            Console.WriteLine(n);
        }
    }
}

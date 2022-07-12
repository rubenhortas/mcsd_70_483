using System;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class LockKeyword
    {
        public static void Start()
        {
            int n = 0;
            object lck = new object();

            var up = Task.Run(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    lock (lck)
                    {
                        n++;
                    }
                }
            });

            for (int i = 0; i < 1000000; i++)
            {
                lock (lck)
                {
                    n--;
                }
            }

            up.Wait();

            Console.WriteLine(n);
        }
    }
}

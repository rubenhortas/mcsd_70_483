using System;
using System.Threading;

namespace Chapter1
{
    public static class ThreadPoolEx
    {
        public static void Start()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });
        }
    }
}

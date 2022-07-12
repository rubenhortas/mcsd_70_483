using System;
using System.Threading;

namespace Chapter1
{
    public static class Multithreading
    {
        public static void Start()
        {
            Thread t = new Thread(new ThreadStart(CommonCode.ThreadMethod));
            
            t.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread. Do some work.");

                // Notify Windows that the thread is finished.
                Thread.Sleep(0);
            }

            // The Thread.Join method is called on the main thread to let it wait until the other threads finishes.
            t.Join();
        }
    }
}

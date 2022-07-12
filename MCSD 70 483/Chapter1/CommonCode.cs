using System;
using System.Threading;

namespace Chapter1
{
    public static class CommonCode
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                // Notify Windows that the thread is finished.
                Thread.Sleep(0);
            }
        }

        public static void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine($"ThreadProc: {i}");
                // Notify Windows that the thread is finished.
                Thread.Sleep(0);
            }
        }
    }
}

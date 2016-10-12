using System;
using System.Threading;

namespace Chapter1
{
    public static class ThreadLocalEx
    {
        /**
         * If you want to use local data in a thread an initialize it for each thread you can use the ThreadLocal<T> class.
         * This class takes a delegate to a method that initializes the value.
         **/

        public static ThreadLocal<int> _field =
            new ThreadLocal<int>(() =>
            {
                return Thread.CurrentThread.ManagedThreadId;
            });

        public static void Start()
        {
            new Thread(() =>
            {
                Console.WriteLine("Thread A ID: {0}", Thread.CurrentThread.ManagedThreadId);
                for (int i = 0; i < _field.Value; i++)
                {
                    Console.WriteLine("Thread A: {0}", i);
                }
            }).Start();

            new Thread(() =>
            {
                Console.WriteLine("Thread B ID: {0}", Thread.CurrentThread.ManagedThreadId);
                for (int i = 0; i < _field.Value; i++)
                {
                    Console.WriteLine("Thread B: {0}", i);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
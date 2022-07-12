using System;
using System.Threading;

namespace Chapter1
{
    // To stop a thread, you can use the Thread.Abort method. However, because this method
    // is executed by another thread, it can happen at any time. When it happens, a ThreadAbortException
    // is thrown on the target thread. This can potentially leave a corrupt state and make
    // your application unusable.
    // A better way to stop a thread is by using a shared variable that both your target and your calling
    // thread can access.
    public static class StoppingThreads
    {
        public static void Start()
        {
            bool stopped = false;

            // Thread is initialized with a lamda expression 
            // (which in turn is just a shorthand version of a delegate).
            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }
            ));

            t.Start();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            stopped = true;

            // The t.Join() mehod causes the console application to wait till the thread finishes execution.
            t.Join();
        }
    }
}

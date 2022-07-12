using System;
using System.Threading.Tasks;

namespace Chapter1
{
    // Task is an object that represents some work that should be done.
    // The task can tell you if the work is completed and if the operation returns a result, the task gives you a result.
    public static class Tasks
    {
        public static void Start()
        {
            Task t = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("*");
                }
            });

            t.Wait();
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class SettingATimeoutOnATask
    {
        public static void Start()
        {
            Task longRunningTask = Task.Run(() =>
            {
                Thread.Sleep(1000);
            });

            int index = Task.WaitAny(new[] { longRunningTask }, 1000);

            if (index == -1)
            {
                Console.WriteLine("Task timed out");
            }
        }
    }
}

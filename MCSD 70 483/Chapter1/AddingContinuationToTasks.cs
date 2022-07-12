using System;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class AddingContinuationToTasks
    {
        public static void Start()
        {
            Task<int> t = Task.Run(() => { return 42; });

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");

            }, TaskContinuationOptions.OnlyOnCanceled);

            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);

            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            completedTask.Wait();
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class CancellationTokenContinueWith
    {
        public static void Start()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task task = Task.Run(() =>
            {
                while (!token.IsCancellationRequested)
                {
                    Console.Write("*");
                    Thread.Sleep(1000);
                }
            }, token).ContinueWith(t =>
            {
                t.Exception.Handle((e) => true);

                Console.WriteLine("You have canceled the task");
                Console.ReadLine();
            }, TaskContinuationOptions.OnlyOnCanceled);

            Console.WriteLine("Press enter to stop the task");
            Console.ReadLine();

            cancellationTokenSource.Cancel();
        }
    }
}

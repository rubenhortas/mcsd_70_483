using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class ScalabilityVsResponsiveness
    {
        // SleepAsyncA uses a thread from the thread pool while sleeping.
        private static Task SleepAsyncA(int millisecondsTimeout)
        {
            return Task.Run(() => Thread.Sleep(millisecondsTimeout));
        }

        // SleepAsyncB does not occupy a thread while waiting for the timer to run.
        private static Task SleepAsyncB(int millisecondsTimeout)
        {
            TaskCompletionSource<bool> tcs = null;
            
            var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
            
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout, -1);
            
            return tcs.Task;
        }

        public static void Start()
        {
            SleepAsyncA(2000);
            SleepAsyncB(4000);
        }
    }
}

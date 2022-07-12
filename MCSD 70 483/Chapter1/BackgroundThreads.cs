using System.Threading;

namespace Chapter1
{
    public static class BackgroundThreads
    {
        public static void Start()
        {
            Thread t = new Thread(new ThreadStart(CommonCode.ThreadMethod))
            {
                // t.IsBackground = true;
                IsBackground = false
            };

            t.Start();
        }
    }
}

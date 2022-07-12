using System.Threading;

namespace Chapter1
{
    public static class ParameterizedThreadStartExample
    {
        public static void Start()
        {
            Thread t = new Thread(new ParameterizedThreadStart(CommonCode.ThreadMethod));

            t.Start(5);
            t.Join();
        }
    }
}

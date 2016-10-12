using System;

namespace Chapter2
{
    public static class Null_CoalescingOperator
    {
        public static void Start()
        {
            int? x = null;
            int y = x ?? -1;

            Console.WriteLine("x: {0}", x);
            Console.WriteLine("y: {0}", y);
            Console.ReadLine();
        }
    }
}

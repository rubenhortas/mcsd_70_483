using System;

namespace Chapter2
{
    public static class ForLoopWithMultipleLoppVariables
    {
        public static void Start()
        {
            int[] values = { 1, 2, 3, 4, 5, 6 };
            for(int x=0, y = values.Length -1; ((x < values.Length) && (y >= 0)); x++, y--)
            {
                Console.Write(values[x]);
                Console.Write(values[y]);
            }
            Console.ReadLine();
        }
    }
}

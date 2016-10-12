﻿using System;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class TasksReturningValues
    {
        public static void Start()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });

            Console.WriteLine(t.Result);
            Console.ReadLine();
        }
    }
}

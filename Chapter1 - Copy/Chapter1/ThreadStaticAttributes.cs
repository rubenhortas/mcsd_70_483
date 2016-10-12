using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class ThreadStaticAttributes
    {
        /**
         * A thread has his own call stack tat stores all the methods that are executed.
         * Local variables are stored on the call stack an are private to the thread.
         * 
         * A thread can also have his own data that's not a local variable.
         * By marking a field with the ThreadStatic attribute each thread gets his own copy of a field.
         * 
         * With the ThreadStatic attribute applied the maximun value of _field becomes 10.
         * If you remove it both threads access the same value and it becomes 20. 
         **/
        [ThreadStatic]
        public static int _field;
        
        public static void Start()
        {
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                }
            }
            ).Start();

            new Thread(() =>
            {
                for (int i = 0; i<10; i++)
                {
                    _field++;
                    Console.WriteLine("Thread B: {0}", _field);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}

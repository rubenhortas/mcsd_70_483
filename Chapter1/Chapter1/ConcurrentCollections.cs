using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    class ConcurrentCollections
    {
        public static void Start()
        {
            BlockingCollection();
            BlockingCollection2();
        }

        private static void BlockingCollection()
        {
            Console.WriteLine("BlockingCollection");
            BlockingCollection<string> col = new BlockingCollection<string>();

            Task read = Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine(col.Take());
                }
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if(string.IsNullOrEmpty(s))
                    {
                        break;
                    }
                    col.Add(s);
                }
            });

            write.Wait();
        }

        // By using the GetConsuming
        private static void BlockingCollection2()
        {

        }
    }
}

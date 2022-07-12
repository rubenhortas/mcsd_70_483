using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter1
{
    class ConcurrentCollections
    {
        public static void BlockingCollection()
        {
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

                    if (string.IsNullOrEmpty(s))
                    {
                        break;
                    }

                    col.Add(s);
                }
            });

            write.Wait();
        }

        // By using the GetConsumingEnumerable method you get an IEnumerable that blocks until it finds a new item.
        public static void BlockingCollection2()
        {
            BlockingCollection<string> col = new BlockingCollection<string>();

            Task read = Task.Run(() =>
            {
                foreach (string s in col.GetConsumingEnumerable())
                {
                    Console.WriteLine(s);
                }
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();

                    if (string.IsNullOrEmpty(s))
                    {
                        break;
                    }

                    col.Add(s);
                }
            });

            write.Wait();
        }


        public static void ConcurrentBag()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            bag.Add(42);
            bag.Add(21);

            if (bag.TryTake(out int result))
            {
                Console.WriteLine(result);
            }

            // TryPeek method is not very useful in a multithreaded environment.
            // It could be that another thread removes the item before you can access it.
            if (bag.TryPeek(out result))
            {
                Console.WriteLine($"There's a next item: {result}");
            }
        }

        // ConcurrentBag also implements IEnumerable<T>, so you can itereate over it.
        // This operation is made thread-safe bu making a snapshot of the collection when you start iterating it,
        // so items added to the collection after you started iterating it won't be visible.
        public static void EnumeratingAconcurrentBag()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });

            Task.Run(() =>
            {
                foreach (int i in bag)
                {
                    Console.WriteLine(i);
                }
            }).Wait();
        }

        public static void ConcurrentStack()
        {
            ConcurrentStack<int> stack = new ConcurrentStack<int>();

            stack.Push(42);

            if (stack.TryPop(out int result))
            {
                Console.WriteLine($"Popped: {result}");
            }

            stack.PushRange(new int[] { 1, 2, 3 });

            int[] values = new int[2];

            stack.TryPopRange(values);

            foreach (int i in values)
            {
                Console.WriteLine(i);
            }
        }


        public static void ConcurrentQueue()
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

            queue.Enqueue(42);

            if (queue.TryDequeue(out int result))
            {
                Console.WriteLine($"Dequeued: {result}");
            }
        }

        public static void ConcurrentDictionary()
        {
            var dict = new ConcurrentDictionary<string, int>();

            if (dict.TryAdd("k1", 42))
            {
                Console.WriteLine("Added");
            }

            if (dict.TryUpdate("k1", 21, 42))
            {
                Console.WriteLine("42 updated to 21");
            }

            dict["k1"] = 42; // Overwrite unconditionally

            int r1 = dict.AddOrUpdate("k1", 3, (s, i) => i * 2);
            int r2 = dict.GetOrAdd("k2", 3);

            Console.WriteLine($"r1: {r1}");
            Console.WriteLine($"r2: {r2}");
        }
    }
}

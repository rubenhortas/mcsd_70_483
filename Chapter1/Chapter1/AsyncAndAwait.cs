using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class AsyncAndAwait
    {
        // You use async keyword to mark a method for asynchronous operations
        // This way you signal to the compiler that something asynchronousis going to happen.
        // A method marked with async just starts running synchroniusly on the current thread.
        // What it does is enable the method to be split into multiple pieces.
        // The boundaries of these pieces are marked with the await keywords.
        // When you use the await keyword, the compiler generates code that will see whether your asynchronous
        // operation is already finished. If it is, your method just continues running synchronously.
        // If is not yet completed, the state machine will hook up a continuation method that should run
        // when the Task completes. Your method yields control to the calling thread, and this thread
        // can be used to do other work.

        public static void Start()
        {
            string result = DownloadContent().Result;
            Console.Write(result);

        }

        private static async Task<string> DownloadContent()
        {
            using(HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("http://www.microsoft.com");
                return result;
            }
        }
    }
}

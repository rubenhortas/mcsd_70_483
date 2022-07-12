using System;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class AttachingChildTasksToParentTask
    {
        public static void Start()
        {
            Task<int[]> parent = Task.Run(() =>
           {
               var results = new int[3];

               new Task(() => results[0] = 0, TaskCreationOptions.AttachedToParent).Start();
               new Task(() => results[1] = 1, TaskCreationOptions.AttachedToParent).Start();
               new Task(() => results[2] = 2, TaskCreationOptions.AttachedToParent).Start();

               return results;
           });

            var finalTask = parent.ContinueWith(
                parentTask =>
                {
                    foreach (int i in parentTask.Result)
                    {
                        Console.WriteLine(i);
                    }
                });

            finalTask.Wait();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter1
{
    public static class TaskFactoryEx
    {
        public static void Start()
        {
            Task<Int32 []> parent = Task.Run(() =>
                {
                    var results = new int[3];
                    TaskFactory taskFactory = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);
                    taskFactory.StartNew(() => results[0] = 0);
                    taskFactory.StartNew(() => results[1] = 1);
                    taskFactory.StartNew(() => results[2] = 2);
                    return results;
                });
        }
    }
}

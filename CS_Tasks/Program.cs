using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CS_Tasks
{
    class Program
    {
      //  static Task gt1, gt2;

        static void Main(string[] args)
        {
            RunTasks();
            Console.WriteLine();
            Console.WriteLine();
            RunTaskRunMethod();
            Console.WriteLine();
            Console.WriteLine();
            TaskContinueWith();
            Console.ReadLine();
        }


        static void WriteConsoleOne(string msg)
        {
            Console.WriteLine($"The First Task {msg}");
        }

        static void WriteConsoleTwo(string msg)
        {
            Console.WriteLine($"The Second Task {msg}");
        }
        static void WriteConsoleThird(string msg)
        {
            Console.WriteLine($"The Third Task {msg}");
        }

        static void RunTasks()
        {
            var _ = Stopwatch.StartNew();
            Console.WriteLine("Running Tasks....");
            var task1 = Task.Factory.StartNew(()=> WriteConsoleOne("Message 1"));
            var task2 = Task.Factory.StartNew(() => WriteConsoleTwo("Message 2"));
            var task3 = Task.Factory.StartNew(() => WriteConsoleThird("Message 3"));
            //task1.Wait();
            //task2.Wait();
            //task3.Wait();
            Task.WaitAll(task1,task2,task3);
            
            _.Stop();
            Console.WriteLine($"Tasks Stopped and completed in {_.Elapsed.TotalSeconds} time");
        }

        static void RunTaskRunMethod()
        {
            var _ = Stopwatch.StartNew();
            Console.WriteLine("Running Tasks....");
            var t1 = new Task(() => WriteConsoleOne("Message 1"));
            t1.Start();
            var t2 = new Task(() => WriteConsoleTwo("Message 2"));
            t2.Start();
            var t3 = new Task(() => WriteConsoleThird("Message 3"));
            t3.Start();
            _.Stop();
            Console.WriteLine($"Tasks Stopped and completed in {_.Elapsed.TotalSeconds} time");
        }

        static void TaskContinueWith()
        {
            var _ = Stopwatch.StartNew();
            Console.WriteLine("Running Tasks....");
            Task task = Task.Factory.StartNew(() => WriteConsoleOne("Message 1"))
                .ContinueWith(delegate { WriteConsoleTwo("Message 2"); })
                .ContinueWith(delegate { WriteConsoleThird("Message 3"); });
                 _.Stop();
            Console.WriteLine($"Tasks Stopped and completed in {_.Elapsed.TotalSeconds} time");
        }
    }
}

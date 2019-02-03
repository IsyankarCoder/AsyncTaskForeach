using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using System.Collections.Generic;

namespace AsyncTaskForeach
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RunAsync2();

            Console.ReadLine();
        }


        public static async Task RunAsync()
        {
            foreach (var x in new[] { 1, 2, 3 })
            {
                await DoSomethingAsync(x);
            }
        }


        public static async Task RunAsync2()
        {
            var tasks = new List<Task>();
            foreach (var x in new[] { 2, 3, 4 })
            {
                var task = DoSomethingAsync(x);
                tasks.Add(task);
            };

            await Task.WhenAll();

        }


        public static async Task DoSomethingAsync(int x)
        {
            Console.WriteLine($"Doing {x} ....({DateTime.Now:hh:mm:ss})");
            await Task.Delay(2000);
            Console.WriteLine($"{x} done .({DateTime.Now:hh:mm:ss})");
        }
    }
}

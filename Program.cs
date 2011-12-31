using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharpAsyncBasic
{
    class Program
    {
        static void log(Object message)
        {
            Console.WriteLine("[" + Thread.CurrentThread.ManagedThreadId + "] " + message);
        }

        static void Main(string[] args)
        {
            log("Main enter");
            MainTest();
            log("Main leave");
            var xx = test(42);
            xx.ContinueWith((x) =>
            {
                log("got result " + x.Result);
            });
            log("main done");
            Console.ReadLine();
        }

        static async void MainTest()
        {
            log("Hello world");
            for (int i = 0; i < 5; i++)
            {
                var y = await test(i);
                log("Hello result " + i + " = " + y);
            }
        }

        static async Task<int> test(int i)
        {
            var x = Task.Run(() =>
            {
                log("computing " + i);
                return i * i;
            });
            return await x;
        }

        static Task<int> test2(int x)
        {
            return Task.FromResult(x + x);
        }
    }
}

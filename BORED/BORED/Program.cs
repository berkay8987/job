using System;
using System.Threading.Tasks;

namespace BORED
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Console.Out.WriteLineAsync("App Started");
            await ExampleAsync();
            await ExampleAsync2();
            await Console.Out.WriteLineAsync("App Ended");
        }

        static async Task ExampleAsync()
        {
            Console.WriteLine("Async Started");
            await Task.Delay(2000);
            Console.WriteLine("Async Ended");
        }

        static async Task ExampleAsync2()
        {
            Console.WriteLine("Another Async Started");
            await Task.Delay(2000);
            Console.WriteLine("Another Async Ended");
        }
    }
}
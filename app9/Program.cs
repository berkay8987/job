using System;
using Serilog;

namespace app9
{
    class Program
    {
        static void Main()
        {
            // Create Logger
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            Log.Information("This program tries to divide a number with 0.");

            int a = 10, b = 0;
            try
            {
                Log.Debug("Dividing {A} by {B}", a, b);
                Console.WriteLine(a / b);
            }
            catch (Exception e)
            {
                Log.Error(e, "Something went wrong");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
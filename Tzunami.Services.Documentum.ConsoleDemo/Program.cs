using Serilog;
using System;
using Tzunami.Docushare.ConsoleDemo;

namespace Tzunami.Services.Documentum.ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                var demo = new DocumentumDemo();
                demo.InteractiveDemo();
                //demo.Run();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in demo");
            }

            Console.Write("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}

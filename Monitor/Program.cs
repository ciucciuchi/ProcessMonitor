using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Monitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var validator = new ArgumentsValidator();

            if (!validator.ValidateArguments(args))
            {
                Console.WriteLine("Input data is invalid. Try again!");
                return;
            }
            Console.WriteLine("Monitoring process. Press E to stop");
            var processName = args[0];
            var processLifetime = args[1];
            var checkingInterval = args[2];
            
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.E))
            {
                Process[] runingProcess = Process.GetProcessesByName(processName);
                foreach (var procces in runingProcess)
                {
                    var processKiller = new ProcessUtility();
                    processKiller.KillProcess(processName, processLifetime,procces);
                    Task.Delay(Convert.ToInt32(checkingInterval) * 60000);
                }
            }
        }
    }
}

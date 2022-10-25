using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Monitor
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //string[] details = CitesteArgumenteDeLaTastaturaSiValideaza();
            if (args.Length != 3)
            {
                Console.WriteLine("Nu ati introdus parametrii corespunzatori. Reincercati!");
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

                    if ((procces.ProcessName == processName) && (DateTime.Now > procces.StartTime.AddMinutes(Convert.ToDouble(processLifetime))))
                    {
                        // kill  running process
                        Console.WriteLine($"Process stoped at {DateTime.Now} and was running for {DateTime.Now - procces.StartTime}");
                        procces.Kill();

                        procces.WaitForExit();

                    }
                    Task.Delay(Convert.ToInt32(checkingInterval) * 60000);
                }
            }
        }


        private static string[] CitesteArgumenteDeLaTastaturaSiValideaza()
        {
            string[] details;
            do
            {
                Console.WriteLine("Introduceti cei 3 parametrii despartiti prin spatiu:");
                string proccesDetails = Console.ReadLine();
                details = proccesDetails.Split(' ');

                if (details.Length != 3)
                {
                    Console.WriteLine("Nu ati introdus parametrii corespunzatori. Reincercati!");
                }

            }
            while (details.Length != 3);
            Console.WriteLine("Press E to stop");
            return details;
        }
    }
}

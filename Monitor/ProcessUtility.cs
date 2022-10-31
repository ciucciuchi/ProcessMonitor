using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor
{
    public class ProcessUtility
    {
        public void KillProcess(string processName, string processLifetime, Process procces)
        {
            if ((procces.ProcessName == processName) && (DateTime.Now > procces.StartTime.AddMinutes(Convert.ToDouble(processLifetime))))
            {
                // kill  running process
                Console.WriteLine($"Process stoped at {DateTime.Now} and was running for {DateTime.Now - procces.StartTime}");
                procces.Kill();

                procces.WaitForExit();
            }
        }
    }
}

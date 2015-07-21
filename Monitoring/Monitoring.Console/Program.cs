using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monitoring.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            const int millisecondsTimeout = 10000; 
            var memory = Bootstrapper.Bootstrapper.GetMemoryMonitor();
            var hardDisk = Bootstrapper.Bootstrapper.GetHardDiskMonitor();

            System.Console.WriteLine("Starting monitoring...");

            memory.StartMonitoring();
            hardDisk.StartMonitoring();

            Thread.Sleep(millisecondsTimeout);

            memory.StopMonitoring();
            hardDisk.StopMonitoring();

            System.Console.WriteLine("--------------MEMORY--------------------");
            var memoryStatistics = Bootstrapper.Bootstrapper.GetMemoryStatistics().GetStatistics(DateTime.MinValue, DateTime.MaxValue);
            foreach (var var in memoryStatistics)
            {
                System.Console.WriteLine(var.Id + " " + var.Date + " " + var.AvailableMemory);
            }
            System.Console.WriteLine("--------------HDD--------------------");
            var diskStatistics = Bootstrapper.Bootstrapper.GetHardDiskStatistics().GetStatistics(DateTime.MinValue, DateTime.MaxValue);
            foreach (var var in diskStatistics)
            {
                System.Console.WriteLine(var.Id + " " + var.Date + " " + var.AvailableFreeSpace);
            }
            
            System.Console.WriteLine("Monitoring was finished...");
            System.Console.Read();
        }
    }
}

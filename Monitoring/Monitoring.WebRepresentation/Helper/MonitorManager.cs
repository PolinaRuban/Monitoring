using System.Threading;

namespace Monitoring.WebRepresentation.Helper
{
    public static class MonitorManager
    {
        public static void TakeNewMonitoring()
        {
            const int millisecondsTimeout = 50;
            var memory = Bootstrapper.Bootstrapper.GetMemoryMonitor();
            var hardDisk = Bootstrapper.Bootstrapper.GetHardDiskMonitor();

            memory.StartMonitoring();
            hardDisk.StartMonitoring();

            Thread.Sleep(millisecondsTimeout);

            memory.StopMonitoring();
            hardDisk.StopMonitoring();
        }

    }
}
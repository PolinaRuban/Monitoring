using Monitoring.Business.HardDiskMonitor;
using Monitoring.Business.HardDiskMonitor.Interfaces;

namespace Monitoring.Database
{
    public class HardDiskDriveStateWriter : MonitoringManager, IHardDiskDriveStateWriter
    {
        public void WriteHardDiskState(HardDiskState hardDiskState)
        {
            lock (context)
            {
                context.HardDiskStatistics.Add(hardDiskState);
                context.SaveChanges();
            }
        }
    }
}

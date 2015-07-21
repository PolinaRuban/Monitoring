using System;
using System.Collections.Generic;
using System.Linq;
using Monitoring.Business.HardDiskMonitor;
using Monitoring.Business.HardDiskMonitor.Interfaces;

namespace Monitoring.Database.Loaders
{
    public class HardDiskStatisticsLoader : MonitoringManager, IHardDiskDriveStatisticsLoader
    {
        public IEnumerable<HardDiskState> LoadStatistics(DateTime startTime, DateTime endTime)
        {
            lock (context)
            {
                return context.HardDiskStatistics.Where(s => startTime <= s.Date && s.Date <= endTime).ToArray();
            }
        }
    }
}

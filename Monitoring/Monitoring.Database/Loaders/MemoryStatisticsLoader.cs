using System;
using System.Collections.Generic;
using System.Linq;
using Monitoring.Business.MemoryMonitor;
using Monitoring.Business.MemoryMonitor.Interfaces;

namespace Monitoring.Database.Loaders
{
    public class MemoryStatisticsLoader : MonitoringManager, IMemoryStatisticsLoader
    {
        public IEnumerable<MemoryState> LoadStatistics(DateTime startTime, DateTime endTime)
        {
            lock (context)
            {
                return context.MemoryStatistics.Where(ms => ms.Date >= startTime && ms.Date <= endTime);
            }
        }
    }
}

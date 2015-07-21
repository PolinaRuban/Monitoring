using System;
using System.Collections.Generic;
using Monitoring.Business.MemoryMonitor.Interfaces;

namespace Monitoring.Business.MemoryMonitor
{
    public class MemoryStatistics
    {
        private readonly IMemoryStatisticsLoader memoryStatistics;

        public MemoryStatistics(IMemoryStatisticsLoader memoryStatisticsLoader)
        {
            memoryStatistics = memoryStatisticsLoader;
        }

        public IEnumerable<MemoryState> GetStatistics(DateTime startDate, DateTime endDate)
        {
            return memoryStatistics.LoadStatistics(startDate, endDate);
        }
    }
}

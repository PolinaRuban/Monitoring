using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitoring.Business.MemoryMonitor;

namespace Monitoring.Business.MemoryMonitor.Interfaces
{
    public interface IMemoryStatisticsLoader
    {
        IEnumerable<MemoryState> LoadStatistics(DateTime startTime, DateTime endTime);
    }
}

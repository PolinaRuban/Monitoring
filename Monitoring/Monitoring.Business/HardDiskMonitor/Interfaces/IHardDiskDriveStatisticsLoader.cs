using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Business.HardDiskMonitor.Interfaces
{
    public interface IHardDiskDriveStatisticsLoader
    {
        IEnumerable<HardDiskState> LoadStatistics(DateTime startTime, DateTime endTime);
    }
}

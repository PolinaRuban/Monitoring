using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitoring.Business.HardDiskMonitor.Interfaces;

namespace Monitoring.Business.HardDiskMonitor
{
    public class HardDiskStatistics
    {
        private readonly IHardDiskDriveStatisticsLoader hardDiskStatisticsLoader;

        public HardDiskStatistics(IHardDiskDriveStatisticsLoader hardDiskStatisticsLoader)
        {
            this.hardDiskStatisticsLoader = hardDiskStatisticsLoader;
        }

        public IEnumerable<HardDiskState> GetStatistics(DateTime startDate, DateTime endDate)
        {
            return hardDiskStatisticsLoader.LoadStatistics(startDate, endDate);
        }
    }
}

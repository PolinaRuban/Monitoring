using System.Data.Entity;
using Monitoring.Business.HardDiskMonitor;
using Monitoring.Business.MemoryMonitor;

namespace Monitoring.Database
{
    internal class MonitoringDbContext : DbContext
    {
        public DbSet<MemoryState> MemoryStatistics { get; set; }
        public DbSet<HardDiskState> HardDiskStatistics { get; set; }
        public DbSet<Drive> Drives { get; set; }
    }
}

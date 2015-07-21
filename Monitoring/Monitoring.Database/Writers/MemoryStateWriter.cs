using Monitoring.Business.MemoryMonitor;
using Monitoring.Business.MemoryMonitor.Interfaces;

namespace Monitoring.Database
{
    public class MemoryStateWriter : MonitoringManager, IMemoryStateWriter
    {
        public void WriteMemoryState(MemoryState memoryState)
        {
            lock (context)
            {
                context.MemoryStatistics.Add(memoryState);
                context.SaveChanges();
            }
        }
    }
}

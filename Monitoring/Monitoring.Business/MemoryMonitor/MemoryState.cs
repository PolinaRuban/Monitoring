using System;

namespace Monitoring.Business.MemoryMonitor
{
    public class MemoryState
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int AvailableMemory { get; set; }
    }
}

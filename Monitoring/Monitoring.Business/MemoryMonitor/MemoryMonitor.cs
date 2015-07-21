using System;
using System.Diagnostics;
using System.Globalization;
using Monitoring.Business.MemoryMonitor.Interfaces;
using Monitoring.Business.MonitoringInterfaces;

namespace Monitoring.Business.MemoryMonitor
{
    public class MemoryMonitor : ResourceMonitor, IMemoryMonitor
    {
        private IMemoryStateWriter writer;

        public MemoryMonitor(IMemoryStateWriter writer)
        {
            this.writer = writer;
            performanceCounter = new PerformanceCounter("Memory", "Available MBytes");
        }

        protected override void WriteMonitoringResource()
        {
            var memoryState = new MemoryState
            {
                Date = DateTime.Now,
                AvailableMemory = Int32.Parse(performanceCounter.NextValue().ToString(CultureInfo.InvariantCulture))
            };
            writer.WriteMemoryState(memoryState);
        }
    }
}

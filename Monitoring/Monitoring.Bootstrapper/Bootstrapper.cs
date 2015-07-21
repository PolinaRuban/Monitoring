using Microsoft.Practices.Unity;
using Monitoring.Business.HardDiskMonitor;
using Monitoring.Business.HardDiskMonitor.Interfaces;
using Monitoring.Business.MemoryMonitor;
using Monitoring.Business.MemoryMonitor.Interfaces;
using Monitoring.Business.MonitoringInterfaces;
using Monitoring.Database;
using Monitoring.Database.Loaders;

namespace Monitoring.Bootstrapper
{
    public static class Bootstrapper
    {   
        private static readonly IUnityContainer unityContainer;

        static Bootstrapper()
        {
            unityContainer = new UnityContainer();
            CompositionModule.RegisterTypes(unityContainer);
        }

        public static IMemoryMonitor GetMemoryMonitor()
        {
            return unityContainer.Resolve<IMemoryMonitor>();
        }

        public static MemoryStatistics GetMemoryStatistics()
        {
            return unityContainer.Resolve<MemoryStatistics>();
        }

        public static IHardDiskMonitor GetHardDiskMonitor()
        {
            return unityContainer.Resolve<IHardDiskMonitor>();
        }

        public static HardDiskStatistics GetHardDiskStatistics()
        {
            return unityContainer.Resolve<HardDiskStatistics>();
        }

    }
}

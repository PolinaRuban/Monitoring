using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public static class CompositionModule
    {
        public static void RegisterTypes(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IMemoryMonitor, MemoryMonitor>();
            unityContainer.RegisterType<IHardDiskMonitor, HardDiskMonitor>();

            unityContainer.RegisterType<IMemoryStateWriter, MemoryStateWriter>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IMemoryStatisticsLoader, MemoryStatisticsLoader>(new ContainerControlledLifetimeManager());

            unityContainer.RegisterType<IHardDiskDriveStateWriter, HardDiskDriveStateWriter>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IHardDiskDriveStatisticsLoader, HardDiskStatisticsLoader>(new ContainerControlledLifetimeManager());
            unityContainer.RegisterType<IHardDiskDriveStateLoader, HardDiskDriveStateLoader>(
                new ContainerControlledLifetimeManager());
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitoring.Business.HardDiskMonitor.Interfaces;
using Monitoring.Business.MonitoringInterfaces;

namespace Monitoring.Business.HardDiskMonitor
{
    public class HardDiskMonitor : ResourceMonitor, IHardDiskMonitor
    {
        private readonly IHardDiskDriveStateWriter diskDriveStateWriter;
        private readonly IHardDiskDriveStateLoader diskDriveStateLoader;

        public HardDiskMonitor(IHardDiskDriveStateWriter diskDriveStateWriter, IHardDiskDriveStateLoader diskDriveStateLoader)
        {
            this.diskDriveStateWriter = diskDriveStateWriter;
            this.diskDriveStateLoader = diskDriveStateLoader;
        }

        protected override void WriteMonitoringResource()
        {
            foreach (var driveInfo in DriveInfo.GetDrives())
            {
                if (driveInfo.IsReady && (driveInfo.DriveType == DriveType.Fixed || driveInfo.DriveType == DriveType.Removable))
                {
                    var drive = diskDriveStateLoader.GetDrive(driveInfo.Name) ?? new Drive { Name = driveInfo.Name };
                    var state = new HardDiskState
                    {
                        Drive = drive,
                        Date = DateTime.Now,
                        AvailableFreeSpace = driveInfo.AvailableFreeSpace
                    };
                    diskDriveStateWriter.WriteHardDiskState(state);
                }
            }
        }
    }
}

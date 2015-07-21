using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Monitoring.Business.HardDiskMonitor;
using Monitoring.Business.HardDiskMonitor.Interfaces;

namespace Monitoring.Database
{
    public class HardDiskDriveStateLoader : MonitoringManager, IHardDiskDriveStateLoader
    {
        //private DriveDbManager() : base()
        //{
        //}

        public Drive GetDrive(string name)
        {
            lock (context)
            {
                var dr = context.Drives.Where(drive => drive.Name.Equals(name));
                return dr.Any() ? dr.First() : null;
            }
        }
    }
}

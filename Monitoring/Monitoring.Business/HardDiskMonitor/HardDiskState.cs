using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoring.Business.HardDiskMonitor
{
    public class HardDiskState
    {
        public HardDiskState()
        {
            Date = DateTime.Now;
        }

        public int Id { get; set; }
        public virtual Drive Drive { get; set; }
        public DateTime Date { get; set; }
        public long AvailableFreeSpace { get; set; }
    }
}

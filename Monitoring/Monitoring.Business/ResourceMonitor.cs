using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadState = System.Threading.ThreadState;

namespace Monitoring.Business
{
    public abstract class ResourceMonitor : IResourceMonitor
    {
        private readonly Thread thread;
        private bool isActive;

        private readonly object locker = new object();

        protected PerformanceCounter performanceCounter;
        public int TimeoutInMiliseconds { get; set; }

        protected ResourceMonitor()
        {
            TimeoutInMiliseconds = 1000;
            thread = new Thread(GetMonitoring)
            {
                Name = "Monitoring Thread",
                CurrentUICulture = new CultureInfo("En-us")
            };
        }

        public void StartMonitoring()
        {
            lock (locker)
            {
                isActive = true;
                thread.Start();
                thread.Priority = ThreadPriority.Highest;
            }
        }

        public void StopMonitoring()
        {
            lock (locker)
            {
                isActive = false;
                //thread.Abort();
            }
            thread.Join();
        }

        private void GetMonitoring()
        {
            //TODO: change while true. 
            while (true)
            {
                lock (locker)
                {
                    if (!isActive)
                        break;
                }

                WriteMonitoringResource();

                Thread.Sleep(TimeoutInMiliseconds);
            }
        }
        protected abstract void WriteMonitoringResource();
    }
}

using System;
using System.Web.Mvc;
using WebPresentation.Helper;

namespace Monitoring.WebRepresentation.Controllers
{
    public class ResourcesController : Controller
    {
        public ActionResult Memory()
        {
            ViewBag.MenuItem = MenuItem.Memory;
            return
                View(Bootstrapper.Bootstrapper.GetMemoryStatistics().GetStatistics(DateTime.MinValue, DateTime.MaxValue));
        }

        public ActionResult HardDiskDrive()
        {
            ViewBag.MenuItem = MenuItem.HardDisk;
            return
                View(Bootstrapper.Bootstrapper.GetHardDiskStatistics().GetStatistics(DateTime.MinValue, DateTime.MaxValue));
        }

        public ActionResult Monitoring()
        {
            ViewBag.MenuItem = MenuItem.Monitoring;

            //Helper.MonitorManager.TakeNewMonitoring();

            return
                View("Memory", Bootstrapper.Bootstrapper.GetMemoryStatistics().GetStatistics(DateTime.MinValue, DateTime.MaxValue));
        }
    }
}
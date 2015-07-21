namespace Monitoring.Database
{
    public class MonitoringManager
    {
        internal readonly MonitoringDbContext context;
        public MonitoringManager()
        {
            System.Data.Entity.Database.SetInitializer(new MonitoringDbInitializer());
            context = new MonitoringDbContext();
        }
    }
}

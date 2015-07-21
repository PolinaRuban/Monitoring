using System.Data.Entity;
using Monitoring.Database;

namespace Monitoring.Database
{
    internal class MonitoringDbInitializer : CreateDatabaseIfNotExists<MonitoringDbContext>
    {
    }
}
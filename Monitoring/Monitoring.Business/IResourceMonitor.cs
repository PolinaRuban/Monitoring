namespace Monitoring.Business
{
    public interface IResourceMonitor
    {
        void StartMonitoring();
        void StopMonitoring();
    }
}

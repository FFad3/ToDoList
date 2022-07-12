using NLog;
using NLog.Web;

namespace ToDoList.Configuration
{
    public class NlogInstaller : IInstaller
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public void Install(WebApplicationBuilder builder)
        {
            // NLog: Setup NLog for Dependency injection
            _logger.Debug("Setup NLog for Dependency injection");
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();
        }
    }
}
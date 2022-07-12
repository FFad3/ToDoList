using NLog;

namespace ToDoList.Configuration
{
    public class MVCInstaller : IInstaller
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public void Install(WebApplicationBuilder builder)
        {
            // Add services to the container.
            _logger.Debug("Add controller with views");
            builder.Services.AddControllersWithViews();
        }
    }
}
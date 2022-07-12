using NLog;

namespace ToDoList.Configuration
{
    public static class ServicesInstaller
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public static void InstallServicesInAsseembly(WebApplicationBuilder builder)
        {
            _logger.Debug("Get list of installers");
            var installers = typeof(Program).Assembly.ExportedTypes.Where(x =>
                typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            _logger.Debug($"Install {installers.Count} installers");
            installers.ForEach(installer => installer.Install(builder));
        }
    }
}
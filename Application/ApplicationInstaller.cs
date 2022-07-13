using Microsoft.Extensions.DependencyInjection;
using Utils.InstallerExtenstion;

namespace Application
{
    public static class ApplicationInstaller
    {
        public static void Install(IServiceCollection services)
        {
            services.RegisterDependencies();
        }
    }
}
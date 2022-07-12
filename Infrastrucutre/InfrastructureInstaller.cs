using Microsoft.Extensions.DependencyInjection;
using Utils.InstallerExtenstion;

namespace Infrastrucutre
{
    public static class InfrastructureInstaller
    {
        public static void Install(IServiceCollection services)
        {
            services.RegisterDependencies();
        }
    }
}
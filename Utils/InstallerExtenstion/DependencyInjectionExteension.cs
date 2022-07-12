using Microsoft.Extensions.DependencyInjection;
using NLog;
using System.Reflection;
using Utils.Attribiutes;

namespace Utils.InstallerExtenstion
{
    public static class DependencyInjectionExteension
    {
        private static ILogger _Logger = LogManager.GetCurrentClassLogger();

        public static void RegisterDependencies(this IServiceCollection services)
        {
            //Pobiera assembly wywołujące metodę
            var asm = Assembly.GetCallingAssembly();

            //pobiera typu które posiadają atrybut : InjectableAttribute
            var types = asm.ExportedTypes
                        .Where(x => x.GetCustomAttributes(typeof(InjectableAttribute), true).Length > 0)
                        .ToList();

            if (types.Count <= 0) return;

            _Logger.Debug($"Dodawanie {types.Count} Serwisów");

            foreach (var type in types)
            {
                var attributes = (InjectableAttribute[])type.GetCustomAttributes(typeof(InjectableAttribute), true);

                var attribute = attributes[0];

                var implementedInterface = attribute.ImplementedInterface;

                _Logger.Debug($"Dodawanie serwisu: {type.Name}:{implementedInterface.Name} --> {attribute.Scope}");
                switch (attribute.Scope)
                {
                    case DependencyInjectionScope.Scoped:
                        services.AddScoped(implementedInterface, type);
                        break;

                    case DependencyInjectionScope.PerDependency:
                        services.AddTransient(implementedInterface, type);
                        break;

                    case DependencyInjectionScope.Singleton:
                        services.AddSingleton(implementedInterface, type);
                        break;
                }
            }
        }
    }
}
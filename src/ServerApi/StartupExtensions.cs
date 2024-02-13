using Microsoft.Extensions.DependencyInjection;
using ServerApi.Managers;

namespace ServerApi
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddApiManagers(this IServiceCollection services)
        {
            var managerInterfaces = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IManager).IsAssignableFrom(x) && x != typeof(IManager) && x.IsInterface);

            foreach (var managerInterface in managerInterfaces)
            {
                var managerImplementation = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Single(x => x.IsAssignableTo(managerInterface) && x.IsClass);

                services.AddScoped(managerInterface, managerImplementation);
            }

            return services;
        }
    }
}

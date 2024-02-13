using Client.ApiClient;
using Client.Constants;
using Client.Interfaces;
using Client.Pages;
using Client.ViewModels.Base;
using ServerApi;
using System.Reflection;

namespace Client
{
    internal static class Startup
    {
        public static void RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services
                .AddPages()
                .AddMenuView()
                .AddViewModels()
                .AddServices()
                .AddApiManagers()
                .AddApiHttpClient()
                .AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        private static IServiceCollection AddApiHttpClient(this IServiceCollection services) 
        {
            services.AddSingleton<HttpInterceptor>();
            var sp = services.BuildServiceProvider();
            var interceptor = sp.GetRequiredService<HttpInterceptor>();
            services.AddSingleton<HttpClient>((x) =>
            {
                return new HttpClient(interceptor)
                {
                    BaseAddress = new Uri(BrandingConstants.ApiUri),
                };
            });

            return services;
        }

        private static IServiceCollection AddPages(this IServiceCollection services)
        {
            var pages = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(ContentPage).IsAssignableFrom(x) && x.IsClass);

            foreach (var page in pages)
            {
                services.AddTransient(page);
            }

            return services;
        }

        private static IServiceCollection AddMenuView(this IServiceCollection services)
        {
            services.AddTransient<AppFlyout>();

            return services;
        }

        private static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            var viewModels = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(x => x.GetTypes())
                            .Where(x => typeof(BaseViewModel).IsAssignableFrom(x) && x.IsClass);

            foreach (var viewModel in viewModels)
            {
                services.AddTransient(viewModel);
            }

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            var serviceInterfaces = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => typeof(IService).IsAssignableFrom(x) && x != typeof(IService) && x.IsInterface);

            foreach (var serviceInterface in serviceInterfaces)
            {
                var serviceImplementation = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Single(x => x.IsAssignableTo(serviceInterface) && x.IsClass);

                services.AddScoped(serviceInterface, serviceImplementation);
            }

            return services;
        }
    }
}

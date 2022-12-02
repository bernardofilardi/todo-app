using Microsoft.Extensions.DependencyInjection;
using ToDo.Application.AppServices;
using ToDo.Application.AutoMapper;
using ToDo.Application.Interfaces;
using ToDo.Domain.Interface;
using ToDo.Infra.Data.Repositories;

namespace ToDo.Infra.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            const string root = "ToDo";
            var scanAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                                      .Where(w => w.FullName.StartsWith(root));

            services.AddAutoMapper((sp, cfg) =>
            {
                cfg.AddProfile(new ServiceProfile());
            }, scanAssemblies, ServiceLifetime.Transient);

            return services;
        }
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IItemAppService, ItemAppService>();
            services.AddScoped<IItemRepository, ItemRepository>();
            return services;
        }
    }
}
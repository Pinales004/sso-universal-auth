using API_BASE.Application.Interfaces;
using API_BASE.Application.Interfaces.Dashboard;
using API_BASE.Infrastructure.Repositories;
using API_BASE.Infrastructure.Servicios.Dashboard;
using FluentAssertions.Common;
using Microsoft.Extensions.DependencyInjection;

namespace API_BASE.Infrastructure.Extensions
{
    public static class InfrastructureServiceExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IDashboardService, DashboardService>();


            return services;
        }


 
    }
}

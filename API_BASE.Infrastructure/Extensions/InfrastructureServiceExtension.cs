using API_BASE.Application.DTOs.Auth;
using API_BASE.Application.Interfaces;
using API_BASE.Application.Interfaces.Auth;
using API_BASE.Application.Interfaces.Authorization;
using API_BASE.Application.Interfaces.Dashboard;
using API_BASE.Application.Interfaces.Mfa;
using API_BASE.Infrastructure.Repositories;
using API_BASE.Infrastructure.Servicios.Auth;
using API_BASE.Infrastructure.Servicios.Authorization;
using API_BASE.Infrastructure.Servicios;
using API_BASE.Infrastructure.Servicios.Dashboard;
using API_BASE.Infrastructure.Servicios.Mfa;
using Microsoft.Extensions.DependencyInjection;

namespace API_BASE.Infrastructure.Extensions
{
    public static class InfrastructureServiceExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddScoped<IDashboardService, DashboardService>();
            // -----------------------------
            // Servicios de Auth / SSO
            // -----------------------------
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();

            // -----------------------------
            // MFA
            // -----------------------------
            services.AddScoped<IMfaService, MfaService>();
            services.AddScoped<ITotpService, TotpService>();

            // -----------------------------
            // Evaluación de permisos
            // -----------------------------
            services.AddScoped<IPolicyEvaluator, PolicyEvaluatorService>();

            // -----------------------------
            // Hashing
            // -----------------------------
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            // -----------------------------
            // Token JWT
            // -----------------------------
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }


 
    }
}

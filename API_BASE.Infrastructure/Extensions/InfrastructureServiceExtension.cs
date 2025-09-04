using API_BASE.Application.DTOs.Auth;
using API_BASE.Application.Interfaces;
using API_BASE.Application.Interfaces.Auth;
using API_BASE.Application.Interfaces.Authorization;
using API_BASE.Application.Interfaces.Dashboard;
using API_BASE.Application.Interfaces.Mfa;
using API_BASE.Application.Interfaces.Usuario;
using API_BASE.Application.Services.Usuario;
using API_BASE.Infrastructure.Repositories;
using API_BASE.Infrastructure.Servicios;
using API_BASE.Infrastructure.Servicios.Auth;
using API_BASE.Infrastructure.Servicios.Authorization;
using API_BASE.Infrastructure.Servicios.Dashboard;
using API_BASE.Infrastructure.Servicios.Mfa;
using Microsoft.Extensions.DependencyInjection;

namespace API_BASE.Infrastructure.Extensions
{
    public static class InfrastructureServiceExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // REPOSITORIOS GENERICOS
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            // AUTO MAPPER
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // SERVICIOS DASHBOARD
            services.AddScoped<IDashboardService, DashboardService>();


            // AUTH / SSO
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();

            // MFA
            services.AddScoped<IMfaService, MfaService>();
            services.AddScoped<ITotpService, TotpService>();

            // EVALUACIÓN DE PERMISOS / AUTORIZACIÓN
            services.AddScoped<IPolicyEvaluator, PolicyEvaluatorService>();

            // HASHING
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            // TOKEN JWT
            services.AddScoped<ITokenService, TokenService>();

            // ---- REGISTRO DE SERVICIOS DE LÓGICA DE NEGOCIO ----
            services.AddScoped<IUsuario, UsuarioService>();
            // services.AddScoped<ISolicitudUsuario, SolicitudUsuarioService>();
            // ...agrega aquí tus otros servicios de negocio...

            // ...otros servicios que quieras agregar...



            return services;
        }


 
    }
}

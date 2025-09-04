using API_BASE.API.Filters;
using API_BASE.Application.Mapping;     // ?? Importa tu config central de mappings
using API_BASE.Application.Mapping.Usuario;
using API_BASE.Application.Settings;
using API_BASE.Infrastructure.Extensions;
using API_BASE.Infrastructure.Persistence;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// 1. Configura JwtSettings
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("Email"));
builder.Services.Configure<SecurityPoliciesSettings>(builder.Configuration.GetSection("SecurityPolicies"));


builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra todos los perfiles autom�ticamente
builder.Services.AddAutoMapper(typeof(UsuarioProfile).Assembly);

// 3. Controllers y filtro de modelo
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidateModelFilter>();
});

// 4. Autenticaci�n JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();
var secretKey = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);


// 5. Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SSO Universal Auth API",
        Version = "v1",
        Description = "API centralizada para autenticaci�n, autorizaci�n y gesti�n de usuarios (Single Sign-On adaptable, arquitectura monol�tica modular en .NET 8)."
    });
});
builder.Services.AddSwaggerGen();

// 6. CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// 7. Inyecci�n de infraestructura (repos, contextos, servicios t�cnicos)
builder.Services.AddInfrastructure();

// 8. Build
var app = builder.Build();

// 9. Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

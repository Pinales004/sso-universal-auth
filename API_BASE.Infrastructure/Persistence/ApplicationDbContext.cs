
using API_BASE.Domain.Base;
using API_BASE.Domain.Entities.Aplicacion;
using API_BASE.Domain.Entities.Mantenimiento;
using API_BASE.Domain.Entities.Mantenimiento.Aplicacion;
using API_BASE.Domain.Entities.Mantenimiento.UsuarioMan;
using API_BASE.Domain.Entities.Notificaciones;
using API_BASE.Domain.Entities.Organismo;
using API_BASE.Domain.Entities.Seguridad;
using API_BASE.Domain.Entities.Usuario;
using API_BASE.Domain.Entities.Usuario.Solicitud;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace API_BASE.Infrastructure.Persistence
{
    public class ApplicationDbContext: DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
                                   IHttpContextAccessor httpContextAccessor)
           : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //Espacio para definir Tablas de la BD

        // Seguridad
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<RolPermiso> RolPermisos { get; set; }
        public DbSet<UsuarioRol> UsuarioRoles { get; set; }
        public DbSet<UsuarioPermiso> UsuarioPermisos { get; set; }
        public DbSet<Nodo> Nodos { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<ConfigPoliticas> ConfigPoliticas { get; set; }

        // Usuarios
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PasswordHistory> PasswordHistories { get; set; }
        public DbSet<LoginAttempt> LoginAttempts { get; set; }
        public DbSet<PasswordResetRequest> PasswordResetRequests { get; set; }
        public DbSet<EmailVerification> EmailVerifications { get; set; }
        public DbSet<MfaTotp> MfaTotps { get; set; }
        public DbSet<MfaRecoveryCode> MfaRecoveryCodes { get; set; }
        public DbSet<SolicitudUsuario> SolicitudesUsuario { get; set; }

        // Notificaciones
        public DbSet<Notificacion> Notificaciones { get; set; }
        public DbSet<NotificacionUsuario> NotificacionesUsuario { get; set; }

        // Organización
        public DbSet<Organismo> Organismos { get; set; }
        public DbSet<UsuarioOrganizacion> UsuarioOrganizaciones { get; set; }

        // Aplicaciones
        public DbSet<Aplicacion> Aplicaciones { get; set; }
        public DbSet<AplicacionPermiso> AplicacionesPermisos { get; set; }

        //Auditoria de tablas automatica
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var username = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Sistema";

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.FechaCreacion = DateTime.UtcNow;
                        entry.Entity.UsuarioCreacion = username;
                        break;

                    case EntityState.Modified:
                        entry.Entity.FechaModificacion = DateTime.UtcNow;
                        entry.Entity.UsuarioModificacion = username;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Filtro global para borrado logico
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(AuditableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(ApplicationDbContext)
                        .GetMethod(nameof(SetSoftDeleteFilter), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)!
                        .MakeGenericMethod(entityType.ClrType);

                    method.Invoke(null, new object[] { modelBuilder });
                }
            }
            modelBuilder.Entity<AuditableEntity>()
                        .Property(e => e.Borrado)
                        .HasDefaultValue(false);

        }

        private static void SetSoftDeleteFilter<T>(ModelBuilder builder) where T : AuditableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.Borrado);
        }


    }
}

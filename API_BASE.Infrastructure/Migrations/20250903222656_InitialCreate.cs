using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_BASE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "aplicaciones");

            migrationBuilder.EnsureSchema(
                name: "seguridad");

            migrationBuilder.EnsureSchema(
                name: "usuarios");

            migrationBuilder.EnsureSchema(
                name: "notificaciones");

            migrationBuilder.EnsureSchema(
                name: "organizacion");

            migrationBuilder.CreateTable(
                name: "Aplicaciones",
                schema: "aplicaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedirectUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientSecret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigPoliticas",
                schema: "seguridad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VigenteDesde = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VigenteHasta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigPoliticas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nodos",
                schema: "seguridad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nodos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nodos_Nodos_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "seguridad",
                        principalTable: "Nodos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                schema: "notificaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UrlDestino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organismos",
                schema: "organizacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organismos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organismos_Organismos_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "organizacion",
                        principalTable: "Organismos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                schema: "seguridad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "seguridad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EsGlobal = table.Column<bool>(type: "bit", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MustChangePassword = table.Column<bool>(type: "bit", nullable: false),
                    EsAdminGlobal = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AplicacionPermisos",
                schema: "aplicaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AplicacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermisoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplicacionPermisos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AplicacionPermisos_Aplicaciones_AplicacionId",
                        column: x => x.AplicacionId,
                        principalSchema: "aplicaciones",
                        principalTable: "Aplicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AplicacionPermisos_Permisos_PermisoId",
                        column: x => x.PermisoId,
                        principalSchema: "seguridad",
                        principalTable: "Permisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolPermisos",
                schema: "seguridad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermisoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AplicacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NodoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Hereda = table.Column<bool>(type: "bit", nullable: false),
                    Denegado = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPermisos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolPermisos_Aplicaciones_AplicacionId",
                        column: x => x.AplicacionId,
                        principalSchema: "aplicaciones",
                        principalTable: "Aplicaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RolPermisos_Nodos_NodoId",
                        column: x => x.NodoId,
                        principalSchema: "seguridad",
                        principalTable: "Nodos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RolPermisos_Permisos_PermisoId",
                        column: x => x.PermisoId,
                        principalSchema: "seguridad",
                        principalTable: "Permisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolPermisos_Roles_RolId",
                        column: x => x.RolId,
                        principalSchema: "seguridad",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auditorias",
                schema: "seguridad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjetivoTipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetivoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganismoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NodoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Metadata = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auditorias_Usuarios_ActorId",
                        column: x => x.ActorId,
                        principalSchema: "usuarios",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "EmailVerifications",
                schema: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TokenHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolicitadoEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiraEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VerificadoEn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailVerifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailVerifications_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "usuarios",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoginAttempts",
                schema: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaIntento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Exitoso = table.Column<bool>(type: "bit", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAttempts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoginAttempts_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "usuarios",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MfaRecoveryCodes",
                schema: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CodeHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsadoEn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MfaRecoveryCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MfaRecoveryCodes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "usuarios",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MfaTotps",
                schema: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Secret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    DeshabilitadoEn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MfaTotps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MfaTotps_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "usuarios",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificacionesUsuario",
                schema: "notificaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificacionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Leida = table.Column<bool>(type: "bit", nullable: false),
                    FechaLectura = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Entregada = table.Column<bool>(type: "bit", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificacionesUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificacionesUsuario_Notificaciones_NotificacionId",
                        column: x => x.NotificacionId,
                        principalSchema: "notificaciones",
                        principalTable: "Notificaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NotificacionesUsuario_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "usuarios",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordHistories",
                schema: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCambio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordHistories_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "usuarios",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordResetRequests",
                schema: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TokenHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolicitadoEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiraEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsadoEn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordResetRequests_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "usuarios",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                schema: "seguridad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiraEn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevocadoEn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MotivoRevocacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sesiones_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "usuarios",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudesUsuario",
                schema: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SolicitanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmailContacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganismoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NodoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Detalle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ResueltoPor = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ComentarioResolucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudesUsuario_Usuarios_SolicitanteId",
                        column: x => x.SolicitanteId,
                        principalSchema: "usuarios",
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioOrganizaciones",
                schema: "organizacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganismoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EsPrincipal = table.Column<bool>(type: "bit", nullable: false),
                    Desde = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hasta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioOrganizaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioOrganizaciones_Organismos_OrganismoId",
                        column: x => x.OrganismoId,
                        principalSchema: "organizacion",
                        principalTable: "Organismos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioOrganizaciones_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "usuarios",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioPermisos",
                schema: "seguridad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermisoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desde = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hasta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioPermisos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioPermisos_Permisos_PermisoId",
                        column: x => x.PermisoId,
                        principalSchema: "seguridad",
                        principalTable: "Permisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioPermisos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "usuarios",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRoles",
                schema: "seguridad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrganismoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Desde = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hasta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_Organismos_OrganismoId",
                        column: x => x.OrganismoId,
                        principalSchema: "organizacion",
                        principalTable: "Organismos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_Roles_RolId",
                        column: x => x.RolId,
                        principalSchema: "seguridad",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "usuarios",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                schema: "seguridad",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SesionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TokenHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiraEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsadoEn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevocadoEn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Borrado = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Sesiones_SesionId",
                        column: x => x.SesionId,
                        principalSchema: "seguridad",
                        principalTable: "Sesiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aplicaciones_Codigo",
                schema: "aplicaciones",
                table: "Aplicaciones",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AplicacionPermisos_AplicacionId",
                schema: "aplicaciones",
                table: "AplicacionPermisos",
                column: "AplicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_AplicacionPermisos_PermisoId",
                schema: "aplicaciones",
                table: "AplicacionPermisos",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_Auditorias_ActorId",
                schema: "seguridad",
                table: "Auditorias",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigPoliticas_Version",
                schema: "seguridad",
                table: "ConfigPoliticas",
                column: "Version",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerifications_UsuarioId",
                schema: "usuarios",
                table: "EmailVerifications",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LoginAttempts_UsuarioId",
                schema: "usuarios",
                table: "LoginAttempts",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MfaRecoveryCodes_UsuarioId",
                schema: "usuarios",
                table: "MfaRecoveryCodes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MfaTotps_UsuarioId",
                schema: "usuarios",
                table: "MfaTotps",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Nodos_ParentId",
                schema: "seguridad",
                table: "Nodos",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificacionesUsuario_NotificacionId",
                schema: "notificaciones",
                table: "NotificacionesUsuario",
                column: "NotificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificacionesUsuario_UsuarioId",
                schema: "notificaciones",
                table: "NotificacionesUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Organismos_ParentId",
                schema: "organizacion",
                table: "Organismos",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordHistories_UsuarioId",
                schema: "usuarios",
                table: "PasswordHistories",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordResetRequests_UsuarioId",
                schema: "usuarios",
                table: "PasswordResetRequests",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Permisos_Codigo",
                schema: "seguridad",
                table: "Permisos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_SesionId",
                schema: "seguridad",
                table: "RefreshTokens",
                column: "SesionId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Nombre",
                schema: "seguridad",
                table: "Roles",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolPermisos_AplicacionId",
                schema: "seguridad",
                table: "RolPermisos",
                column: "AplicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermisos_NodoId",
                schema: "seguridad",
                table: "RolPermisos",
                column: "NodoId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermisos_PermisoId",
                schema: "seguridad",
                table: "RolPermisos",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermisos_RolId_PermisoId_AplicacionId",
                schema: "seguridad",
                table: "RolPermisos",
                columns: new[] { "RolId", "PermisoId", "AplicacionId" },
                unique: true,
                filter: "[AplicacionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_UsuarioId",
                schema: "seguridad",
                table: "Sesiones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesUsuario_SolicitanteId",
                schema: "usuarios",
                table: "SolicitudesUsuario",
                column: "SolicitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioOrganizaciones_OrganismoId",
                schema: "organizacion",
                table: "UsuarioOrganizaciones",
                column: "OrganismoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioOrganizaciones_UsuarioId",
                schema: "organizacion",
                table: "UsuarioOrganizaciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPermisos_PermisoId",
                schema: "seguridad",
                table: "UsuarioPermisos",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioPermisos_UsuarioId",
                schema: "seguridad",
                table: "UsuarioPermisos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRoles_OrganismoId",
                schema: "seguridad",
                table: "UsuarioRoles",
                column: "OrganismoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRoles_RolId",
                schema: "seguridad",
                table: "UsuarioRoles",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRoles_UsuarioId",
                schema: "seguridad",
                table: "UsuarioRoles",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                schema: "usuarios",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplicacionPermisos",
                schema: "aplicaciones");

            migrationBuilder.DropTable(
                name: "Auditorias",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "ConfigPoliticas",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "EmailVerifications",
                schema: "usuarios");

            migrationBuilder.DropTable(
                name: "LoginAttempts",
                schema: "usuarios");

            migrationBuilder.DropTable(
                name: "MfaRecoveryCodes",
                schema: "usuarios");

            migrationBuilder.DropTable(
                name: "MfaTotps",
                schema: "usuarios");

            migrationBuilder.DropTable(
                name: "NotificacionesUsuario",
                schema: "notificaciones");

            migrationBuilder.DropTable(
                name: "PasswordHistories",
                schema: "usuarios");

            migrationBuilder.DropTable(
                name: "PasswordResetRequests",
                schema: "usuarios");

            migrationBuilder.DropTable(
                name: "RefreshTokens",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "RolPermisos",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "SolicitudesUsuario",
                schema: "usuarios");

            migrationBuilder.DropTable(
                name: "UsuarioOrganizaciones",
                schema: "organizacion");

            migrationBuilder.DropTable(
                name: "UsuarioPermisos",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "UsuarioRoles",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "Notificaciones",
                schema: "notificaciones");

            migrationBuilder.DropTable(
                name: "Sesiones",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "Aplicaciones",
                schema: "aplicaciones");

            migrationBuilder.DropTable(
                name: "Nodos",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "Permisos",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "Organismos",
                schema: "organizacion");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "seguridad");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "usuarios");
        }
    }
}

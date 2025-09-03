# 📚 SSO Universal Auth – Wiki

Bienvenido a la documentación del proyecto **SSO Universal Auth (.NET 8)**,  
un sistema Single Sign-On adaptable, escalable y desacoplado, siguiendo Clean Architecture y DDD.

---

## 🔷 Descripción General

- **Framework:** .NET 8
- **Arquitectura:** Clean Architecture + DDD
- **Base de datos:** SQL Server (modificable a otros)
- **Dominio:** Multi-organización, multi-aplicación, seguro y extensible.

---

## 🏛️ Arquitectura y Carpetas

/src
/API_BASE.Domain/ # Entidades, enums, lógica de dominio
/API_BASE.Application/ # DTOs, mapeos, servicios, interfaces, settings
/API_BASE.Infrastructure/ # Persistencia, repositorios, servicios infra, migraciones
/API_BASE.API/ # Controladores, Program.cs, Middlewares
/API_BASE.Shared/ # Utilidades comunes, respuestas, errores


---

## 🚦 Principales Características

- Autenticación JWT (access/refresh token, claims personalizados)
- Gestión de usuarios, roles, permisos y nodos (RBAC)
- Multi-organización y multi-aplicación
- Historial de contraseñas y lockout automático
- MFA (TOTP), verificación de email, recuperación segura
- Notificaciones multicanal (in-app, email, SMS)
- Auditoría de acciones y cambios
- Seeds de datos, migraciones automáticas
- Servicios desacoplados y reutilizables (JWT, Email, Hash, Auditoría, Notificación, Plantillas)

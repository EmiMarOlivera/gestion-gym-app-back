# gestion-gym-app
Repositorio Proyecto Final ORT ATI 263478
## Estructura

La API está en la carpeta `WebApi` y se organiza en cuatro proyectos por capa (ver DT-01 en `docs/decisiones-tecnicas.md`):

- **Domain**: entidades.
- **AppLogic**: casos de uso y DTOs.
- **DataAccess**: DbContext y acceso a datos con Entity Framework Core.
- **WebApi**: controllers y endpoints.

## Cómo correr la API en local

### Requisitos

- .NET 10 SDK
- Docker Desktop

### 1. Levantar SQL Server en Docker

```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<tu-contraseña>" -p 1433:1433 --name sql-gym -d mcr.microsoft.com/mssql/server:2022-latest
```

La contraseña debe tener al menos 8 caracteres, con mayúscula, minúscula, número y símbolo.
Las veces siguientes alcanza con `docker start sql-gym`.

### 2. Configurar la cadena de conexión

La cadena se guarda con user secrets, fuera del repositorio. Desde `WebApi/WebApi`:

```
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1433;Database=FitnessDb;User Id=sa;Password=<tu-contraseña>;TrustServerCertificate=True"
```

### 3. Ejecutar

Desde `WebApi`:

```
dotnet run --project WebApi
```

Para comprobar que responde: `http://localhost:5113/weatherforecast`
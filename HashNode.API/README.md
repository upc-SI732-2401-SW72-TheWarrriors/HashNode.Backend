# HashNode.API

HashNode.API es un proyecto de API REST desarrollado en .NET 8 que sigue la arquitectura de Vertical Slice para la gestión de conferencias, usuarios, publicaciones y comentarios. Esta API proporciona un conjunto de endpoints para la creación, actualización, eliminación y consulta de estos recursos.

## Tecnologías y Herramientas

- **.NET 8**: Framework de desarrollo
- **Entity Framework Core**: ORM para el acceso y manejo de la base de datos
- **AutoMapper**: Utilizado para el mapeo entre objetos DTO y entidades de dominio
- **Swagger**: Para la documentación y pruebas de la API

## Requisitos Previos

Para correr este proyecto necesitas tener instalado:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Un sistema gestor de bases de datos compatible (SQL Server, PostgreSQL, etc.), dependiendo de tu configuración en `appsettings.json`

## Cómo Correr el Proyecto

1. **Clonar el Repositorio**

` git clone https://github.com/upc-SI732-2401-SW72-TheWarrriors/HashNode.API.git `

2. **Instalar Dependencias**

` dotnet restore `

3. **Crear la Base de Datos**

` dotnet ef database update `

4. **Correr el Proyecto**

` dotnet run `

5. **Acceder a la Documentación de la API**

` https://localhost:5001/swagger/index.html `

## Endpoints

### Conferencias

- **GET /api/conferences**: Obtiene todas las conferencias

- **GET /api/conferences/{id}**: Obtiene una conferencia por su ID

- **POST /api/conferences**: Crea una nueva conferencia

- **PUT /api/conferences/{id}**: Actualiza una conferencia por su ID

- **DELETE /api/conferences/{id}**: Elimina una conferencia por su ID

## Estructura de Carpetas

Una visión general simplificada de la estructura de carpetas del proyecto:

```
HashNode.API/
├───AccessIdentityManagement
│ ├───Domain
│ └───Presentation
├───ConferenceManagement
│ ├───Application
│ ├───Domain
│ ├───Infrastructure
│ └───Presentation
├───FeedManagement
│ ├───Application
│ ├───Domain
│ ├───Infrastructure
│ └───Presentation
├───Shared
│ ├───Domain
│ ├───Extensions
│ └───Infrastructure
└───Properties
```


## Licencia


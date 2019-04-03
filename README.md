# kindergarden
Cuaderno de comunicaciones de jardín que propone cambiar la comunicación entre la institución y los padres, utilizando nuevas tecnologías.

# Introducción
Proyecto en desarrollo para la cátedra de Diseño de Base de Datos, perteneciente a la maestría en Ingeniería de Software (UNLP).

# Organización
La solución consta de dos partes. La API realizada en ASP.NET Core 2 y el cliente, una aplicación Angular que se conecta con la primera.

Dentro de la API existen varios proyectos, que se compilan por separado y corresponden a las distintas responsabilidades que cada módulo tiene dentro de la solución.

## Domain
Contiene entidades, enumerativos, excepciones, tipos y lógica específica del dominio. Las clases relacionadas con Entity Framework son abstractas, y pueden considerarse junto con .NET Core. Es agnóstico de una implementación de base de datos en particular, pudiendo probarse con un providers InMemory, SqlLite, Sql Server y otros.

## Application
Contiene lógica de la aplicación, depende de la capa de dominio pero de ninguna otra. Define interfaces que serán luego implementadas por otras capas.

## Infrastructure
Contiene clases para acceder a recursos externos tales como file systems, web services, smtp, y demás. Estas clases deben estar basadas en las interfaces definidas en Application.

## Persistence
Implementa la capa de persistencia. Aquí tenemos la dependencia a Entity Framework Core. También hacemos referencia a Domain, cuyo modelo se persistirá.

# Referencias
Trabajo basado en la implementación de Jason Taylor de Clean Architecture.

GitHub: https://github.com/JasonGT/NorthwindTraders
Presentación en YouTube: https://www.youtube.com/watch?v=Zygw4UAxCdg&t=71s ("Clean Architecture with ASP.NET Core 2.2 - Jason Taylor")

Otros recursos:
* https://github.com/dotnet-architecture/eShopOnWeb
Sample ASP.NET Core 2.2 reference application, powered by Microsoft, demonstrating a layered application architecture with monolithic deployment model. Download 130+ page eBook PDF from docs folder.

* https://github.com/ivanpaulovich/clean-architecture-manga
Manga is a Service Template to help you to build evolvable, adaptable and maintainable applications. It follows the Clean Architecture Principles (Robert C. Martin, 2017) and Domain-Driven Design. Tests guided us on the implementation so all the components are testable in isolation.

* https://github.com/jbogard/MediatR
Simple, unambitious mediator implementation in .NET. In-process messaging with no dependencies.
Supports request/response, commands, queries, notifications and events, synchronous and async with intelligent dispatching via C# generic variance.
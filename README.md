# kindergarden
Cuaderno de comunicaciones de jardín que propone cambiar la comunicación entre la institución y los padres, utilizando nuevas tecnologías.

# Introducción
Proyecto en desarrollo para la cátedra de Diseño de Base de Datos, perteneciente a la maestría en Ingeniería de Software (UNLP).

Actualmente la comunicación del jardín para con los padres se realiza principalmente mediante el cuaderno de comunicaciones, y un grupo de WhatsApp con una selección de padres de cada sala, los cuales están designados como responsables de comunicar al resto de los padres las notificaciones que el jardín les envía, o canalizar consultas de los padres hacia el jardín. Además, se ha vuelto una práctica muy común el hecho de avisar enfermedades o llegadas tarde a través de otros padres que tengan la posibilidad de hablar directamente con la docente.

Estos mecanismos tienen algunas desventajas:
- El olvido del cuaderno por parte de los padres, o de firmar las notificaciones
- La docente no puede enviar notificaciones en el cuaderno cuando el alumno falta a clase
- La comunicación de enfermedades y otros eventos se torna informal
- Los certificados de enfermedad se demoran más en ser enviados al jardín, atrasando de esta forma cualquier acción preventiva por parte del mismo
- La comunicación del jardín a través de unos pocos padres de alumnos puede generar malentendidos
- Eventos sorpresivos como suspensión de clases por falta de agua o energía eléctrica suelen generar confusión

La idea del proyecto es proveer un nuevo mecanismo de comunicación entre padres y docentes del jardín. Para esto se provee de una app mobile, desde la cual los docentes podrán enviar notificaciones públicas, a cada grupo de padres de una sala en particular, o a los padres de un alumno específicamente. A su vez, los padres pdrán leer y confirmar la lectura de estas notificaciones, de manera de reemplazar el cuaderno de comunicaciones físico. 

Por otro lado, los padres podrán comunicarse con su docente para informar enfermedades, adjuntar certificados, avisar por llegada tarde y demás eventos que pudieran ocurrir. En este caso los eventos están predefinidos por el jardín, y no podrá agregarse texto libre a los mensajes.

# Organización del proyecto
La solución consta de dos partes. La API realizada en ASP.NET Core 2 y el cliente, una aplicación Mobile realizada con Ionic y Angular que se conecta con la primera. Se planea también una versión Web desde la que se podrá administrar el sitio.

La arquitectura de la API puede graficarse de la siguiente forma:

![Arquitectura del sistema](https://image.slidesharecdn.com/buildingenterpriseappswithaspnetcore-180621011258/95/building-enterprise-apps-with-aspnet-core-21-6-638.jpg?cb=1529555693)

Dentro de la misma existen varios proyectos, que se compilan por separado y corresponden a las distintas responsabilidades que cada módulo tiene dentro de la solución.

## Domain
Contiene entidades, enumerativos, excepciones, tipos y lógica específica del dominio. Las clases relacionadas con Entity Framework son abstractas, y pueden considerarse junto con .NET Core. Es agnóstico de una implementación de base de datos en particular, pudiendo probarse con diferentes providers como InMemory, SqlLite, Sql Server y otros.

## Application
Contiene lógica de la aplicación, depende de la capa de dominio pero de ninguna otra. Define interfaces que serán luego implementadas por otras capas. Utiliza AutoMapper, FluentValidation y MediatR (ver referencias). Tiene también una referencia a Persistence, del cual obtiene el contexto.

## Infrastructure
Contiene clases para acceder a recursos externos tales como file systems, web services, smtp, y demás. Estas clases deben estar basadas en las interfaces definidas en Application.

## Persistence
Implementa la capa de persistencia y contiene toda la configuración para mapear los objetos de dominio en un modelo relacional. 
Contiene una referencia a Domain, cuyo modelo se persistirá. Hay también referencias a EF Core y Microsoft.EntityFrameworkCore.SqlServer ya que es el motor de base de datos elegido.

# Cómo usar
- Abrir con Visual Studio 2017
- Configurar credenciales de base de datos en Kindergarden.API\appsettings.json
- Abrir nuget package manager, seleccionar proyecto Persistence y ejecutar: update-database
- Ejecutar
- En /swagger se dispone de una UI desde la que se pueden realizar invocaciones a la API. Solo un subconjunto se encuentra activo actualmente, otros datos se encuentran pre-cargados en la base de datos para poder utilizar y probar estos métodos.

# Cómo cambiar de opciones de persitencia

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
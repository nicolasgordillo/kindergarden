using Kindergarden.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kindergarden.Persistence
{
    /* Carga algunos datos de configuración y prueba */
    public class KindergardenInitializer
    {
        public static void Initialize(KindergardenContext context)
        {
            var initializer = new KindergardenInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(KindergardenContext context)
        {
            context.Database.EnsureCreated();

            if (context.Roles.Any())
            {
                return; // Db has been seeded
            }

            SeedRoles(context);
        }

        public void SeedRoles(KindergardenContext context)
        {
            var roles = new[]
            {
                new Role { Name = "Pariente", CanSendMessage = true, CanSendNotification = false },
                new Role { Name = "Docente", CanSendMessage = false, CanSendNotification = true }
            };

            context.Roles.AddRange(roles);

            var documentTypes = new[]
           {
                new DocumentType { Description = "DNI"}
            };

            context.DocumentTypes.AddRange(documentTypes);

            context.SaveChanges();
        }
    }
}

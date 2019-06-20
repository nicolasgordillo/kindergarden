using Kindergarden.Domain.Entities;
using Kindergarden.Domain.ValueObjects;
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
            var teacherRole = new Role { Name = "Docente", CanSendMessage = false, CanSendNotification = true };
            var parentRole = new Role { Name = "Pariente", CanSendMessage = true, CanSendNotification = false };
            var roles = new[]
            {
                parentRole,
                teacherRole
            };

            context.Roles.AddRange(roles);

            var dniType = new DocumentType { Description = "DNI" };
            var documentTypes = new[]
            {
                dniType
            };

            context.DocumentTypes.AddRange(documentTypes);

            //Add individuals - parents and teachers
            var teacher = new Individual()
            {
                CellPhone = "555-5555",
                Email = Email.For("maestra@jardin.com"),
                DocumentType = dniType,
                FirstName = "Agustina",
                LastName = "Rodriguez"
            };

            teacher.Roles.Add(new PersonRole() { Person = teacher, Role = teacherRole });

            var parent1 = new Individual()
            {
                CellPhone = "555-1234",
                Email = Email.For("parent1@gmail.com"),
                DocumentType = dniType,
                FirstName = "Juan",
                LastName = "Lopez",
                WorkPhone = "555-6789",
            };

            parent1.Roles.Add(new PersonRole() { Person = parent1, Role = parentRole });

            var parent2 = new Individual()
            {
                CellPhone = "433-6789",
                Email = Email.For("parent2@gmail.com"),
                DocumentType = dniType,
                FirstName = "Lucia",
                LastName = "Ramon",
                WorkPhone = "555-5432",
            };

            parent2.Roles.Add(new PersonRole() { Person = parent2, Role = parentRole });

            context.Individuals.Add(teacher);
            context.Individuals.Add(parent1);
            context.Individuals.Add(parent2);

            var student1 = new Student()
            {
                DocumentType = dniType,
                FirstName = "Pedro",
                LastName = "Lopez",
            };

            student1.FamilyMembers.Add(new StudentFamilyMember() { Student = student1, FamilyMember = parent1, Relationship = Domain.Enumerations.FamilyMemberEnum.Father });

            var student2 = new Student()
            {
                DocumentType = dniType,
                FirstName = "Juan",
                LastName = "Ramon",
            };

            student2.FamilyMembers.Add(new StudentFamilyMember() { Student = student2, FamilyMember = parent2, Relationship = Domain.Enumerations.FamilyMemberEnum.Mother });

            context.Students.Add(student1);
            context.Students.Add(student2);

            var salaRosa = new Group() { Description = "Sala Rosa", Active = true, Section = "1C", TimeSpan = Domain.Enumerations.TimespanEnum.Afternoon, Year = 2019, Teacher = teacher };
            salaRosa.FamilyMembers.Add(new IndividualGroup() { FamilyMember = parent1, Group = salaRosa });
            salaRosa.FamilyMembers.Add(new IndividualGroup() { FamilyMember = parent2, Group = salaRosa });

            context.Groups.Add(salaRosa);

            context.SaveChanges();
        }
    }
}

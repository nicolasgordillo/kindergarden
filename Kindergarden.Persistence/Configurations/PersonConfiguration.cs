using Kindergarden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarden.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            //Individios mayores y estudiantes serán mapeados a una tabla persona en la db, el campo PersonType define cual corresponde
            //Entity Framework Core no soporta aun tablas por tipo (TPT),  o tablas por tipo concreto (TPC)
            //Ver https://github.com/aspnet/EntityFrameworkCore/issues/2266 y https://github.com/aspnet/EntityFrameworkCore/issues/3170
            builder
                .ToTable("Persons")
                .HasDiscriminator<int>("PersonType")
                .HasValue<Individual>(1)
                .HasValue<Student>(2);
        }
    }
}

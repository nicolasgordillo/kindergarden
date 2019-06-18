using Kindergarden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarden.Persistence.Configurations
{
    public class PersonRoleConfiguration : IEntityTypeConfiguration<PersonRole>
    {
        public void Configure(EntityTypeBuilder<PersonRole> builder)
        {
            builder.HasKey(bc => new { bc.PersonId, bc.RoleId });

            builder
                .HasOne(bc => bc.Person)
                .WithMany(b => b.Roles)
                .HasForeignKey(bc => bc.PersonId);

            builder
                .HasOne(bc => bc.Role)
                .WithMany(c => c.Persons)
                .HasForeignKey(bc => bc.RoleId);
        }
    }
}

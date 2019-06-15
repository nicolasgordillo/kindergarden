using Kindergarden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarden.Persistence.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Description).IsRequired().HasMaxLength(200);
            builder.Property(e => e.Section).HasMaxLength(10);

            builder.HasOne(g => g.Teacher);

            builder.HasMany(d => d.FamilyMembers);
        }
    }
}

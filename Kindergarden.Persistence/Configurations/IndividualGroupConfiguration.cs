using Kindergarden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarden.Persistence.Configurations
{
    public class IndividualGroupConfiguration : IEntityTypeConfiguration<IndividualGroup>
    {
        public void Configure(EntityTypeBuilder<IndividualGroup> builder)
        {
            builder.HasKey(bc => new { bc.FamilyMemberId, bc.GroupId });

            builder
                .HasOne(bc => bc.FamilyMember)
                .WithMany(b => b.Groups)
                .HasForeignKey(bc => bc.FamilyMemberId);

            builder
                .HasOne(bc => bc.Group)
                .WithMany(c => c.FamilyMembers)
                .HasForeignKey(bc => bc.GroupId);
        }
    }
}

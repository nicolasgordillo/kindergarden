using Kindergarden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarden.Persistence.Configurations
{
    public class StudentFamilyMemberConfiguration : IEntityTypeConfiguration<StudentFamilyMember>
    {
        public void Configure(EntityTypeBuilder<StudentFamilyMember> builder)
        {
            builder.HasKey(bc => new { bc.FamilyMemberId, bc.StudentId });

            builder
                .HasOne(bc => bc.FamilyMember)
                .WithMany(b => b.Students)
                .HasForeignKey(bc => bc.FamilyMemberId);

            builder
                .HasOne(bc => bc.Student)
                .WithMany(c => c.FamilyMembers)
                .HasForeignKey(bc => bc.StudentId);
        }
    }
}

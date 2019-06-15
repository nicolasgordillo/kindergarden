using Kindergarden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarden.Persistence.Configurations
{
    public class IndividualConfiguration : IEntityTypeConfiguration<Individual>
    {
        public void Configure(EntityTypeBuilder<Individual> builder)
        {
            //No tiene Key ya que es un tipo derivado de Person

            builder.HasMany(i => i.SentMessages)
                .WithOne(t => t.SentBy)
                .IsRequired();

            builder.HasMany(i => i.ReceivedMessages)
                .WithOne(t => t.SentTo)
                .IsRequired();

            builder.OwnsOne(u => u.Email);
        }
    }
}

using Kindergarden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarden.Persistence.Configurations
{
    public class MessageTypeConfiguration : IEntityTypeConfiguration<MessageType>
    {
        public void Configure(EntityTypeBuilder<MessageType> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}

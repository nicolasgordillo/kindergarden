using Kindergarden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindergarden.Persistence.Configurations
{
    public class PersonNotificationConfiguration : IEntityTypeConfiguration<PersonNotification>
    {
        public void Configure(EntityTypeBuilder<PersonNotification> builder)
        {
            builder.HasKey(bc => new { bc.NotificationId, bc.ReceiverId });

            builder
                .HasOne(bc => bc.Receiver)
                .WithMany(b => b.ReceivedNotifications)
                .HasForeignKey(bc => bc.ReceiverId);

            builder
                .HasOne(bc => bc.Notification)
                .WithMany(c => c.IndividualNotifications)
                .HasForeignKey(bc => bc.NotificationId);
        }
    }
}

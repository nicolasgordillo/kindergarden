using Kindergarden.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    /* Esta clase representa una notificación del jardín a los padres. Tiene texto libre. */
    public class Notification
    {
        public Notification()
        {
            IndividualNotifications = new HashSet<PersonNotification>();
        }
        public int Id { get; set; }

        public DateTime SentDate { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public Individual Receiver { get; set; }
        public Group Group { get; set; }
        public NotificationTypeEnum Type { get; set; }

        public ICollection<PersonNotification> IndividualNotifications { get; private set; }
    }
}

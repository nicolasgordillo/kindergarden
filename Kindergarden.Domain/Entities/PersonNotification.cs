using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    public class PersonNotification
    {
        public int ReceiverId { get; set; }
        public Individual Receiver { get; set; }
        public int NotificationId { get; set; }
        public Notification Notification { get; set; }

        public bool Read { get; set; }
        public DateTime? ReadDate { get; set; }
        public bool Confirmed { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}

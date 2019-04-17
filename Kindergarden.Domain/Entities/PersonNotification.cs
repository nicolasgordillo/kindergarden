using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    public class PersonNotification
    {
        public int Id { get; set; }
        public Person Receiver { get; set; }
        public Notification Notification { get; set; }

        public bool Read { get; set; }
        public DateTime? ReadDate { get; set; }
        public bool Confirmed { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}

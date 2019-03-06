using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    public class PrivateNotification
    {
        public bool Read { get; set; }
        public bool Confirmed { get; set; }
        public bool Deleted { get; set; }

        public Kin Receiver { get; set; }
    }
}

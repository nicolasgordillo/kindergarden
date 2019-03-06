using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    public class GroupNotification
    {
        public GroupNotification()
        {
            ReadBy = new HashSet<Kin>();
            ConfirmedBy = new HashSet<Kin>();
            DeletedBy = new HashSet<Kin>();
        }

        public ICollection<Kin> ReadBy { get; private set; }
        public ICollection<Kin> ConfirmedBy { get; private set; }
        public ICollection<Kin> DeletedBy { get; private set; }

        public Group Receiver { get; set; }
    }
}

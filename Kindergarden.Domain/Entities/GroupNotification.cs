using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    public class GroupNotification
    {
        public GroupNotification()
        {
            ReadBy = new HashSet<Person>();
            ConfirmedBy = new HashSet<Person>();
            DeletedBy = new HashSet<Person>();
        }

        public ICollection<Person> ReadBy { get; private set; }
        public ICollection<Person> ConfirmedBy { get; private set; }
        public ICollection<Person> DeletedBy { get; private set; }

        public Group Receiver { get; set; }
    }
}

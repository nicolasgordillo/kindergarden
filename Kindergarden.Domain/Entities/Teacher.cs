using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    public class Teacher
    {
        public Teacher()
        {
            Groups = new HashSet<Group>();
            ReceivedMessages = new HashSet<Message>();
        }

        public ICollection<Group> Groups { get; private set; }
        public ICollection<Message> ReceivedMessages { get; private set; }
    }
}

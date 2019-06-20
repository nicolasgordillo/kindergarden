using Kindergarden.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    public class Individual : Person
    {
        public Individual()
        {
            Groups = new HashSet<IndividualGroup>();
            SentMessages = new HashSet<Message>();
            ReceivedMessages = new HashSet<Message>();
            Students = new HashSet<StudentFamilyMember>();
            Roles = new HashSet<PersonRole>();
        }

        public string CellPhone { get; set; }
        public string Phone { get; set; }

        public string WorkPhone { get; set; }
        public Email Email { get; set; }

        public ICollection<IndividualGroup> Groups { get; private set; }
        public ICollection<Message> SentMessages { get; private set; }
        public ICollection<Message> ReceivedMessages { get; private set; }
        public ICollection<PersonNotification> ReceivedNotifications { get; private set; }
        public ICollection<StudentFamilyMember> Students { get; private set; }
        public ICollection<PersonRole> Roles { get; private set; }

        public bool CanSendNotification()
        {
            return this.Roles.Any(x => x.Role.CanSendNotification);
        }

        public bool CanSendMessage()
        {
            return this.Roles.Any(x => x.Role.CanSendMessage);
        }
    }
}

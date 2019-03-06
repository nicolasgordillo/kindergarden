using Kindergarden.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    public class Kin : Person
    {
        public Kin()
        {
            Groups = new HashSet<Group>();
            SentMessages = new HashSet<Message>();
            Students = new HashSet<StudentFamilyMember>();
        }

        public string WorkPhone { get; set; }
        public Email Email{ get; set; }

        public ICollection<Group> Groups { get; private set; }
        public ICollection<Message> SentMessages { get; private set; }
        public ICollection<StudentFamilyMember> Students { get; private set; }
    }
}

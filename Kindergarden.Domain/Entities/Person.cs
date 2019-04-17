using Kindergarden.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    public class Person
    {
        public Person()
        {
            Groups = new HashSet<Group>();
            SentMessages = new HashSet<Message>();
            ReceivedMessages = new HashSet<Message>();
            Students = new HashSet<StudentFamilyMember>();
        }

        public int Id { get; set; }

        public DocumentType DocumentType { get; set; }
        public int DocumentId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string CellPhone { get; set; }
        public string Phone { get; set; }

        //TODO: Como manejo el hecho de que estas colecciones y datos pueden estar vacios al subir a Person? Un Teacher no tiene work phone
        public string WorkPhone { get; set; }
        public Email Email { get; set; }

        public ICollection<Group> Groups { get; private set; }
        public ICollection<Message> SentMessages { get; private set; }
        public ICollection<Message> ReceivedMessages { get; private set; }
        public ICollection<PersonNotification> ReceivedNotifications { get; private set; }
        public ICollection<StudentFamilyMember> Students { get; private set; }
    }
}

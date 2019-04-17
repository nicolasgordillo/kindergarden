using System;
using System.Collections.Generic;

namespace Kindergarden.Domain.Entities
{
    public class Student
    {
        public Student()
        {
            FamilyMembers = new HashSet<StudentFamilyMember>();
        }

        public int Id { get; set; }

        public DocumentType DocumentType { get; set; }
        public int DocumentId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<StudentFamilyMember> FamilyMembers { get; private set; }
    }
}

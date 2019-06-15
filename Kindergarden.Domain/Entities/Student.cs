using System;
using System.Collections.Generic;

namespace Kindergarden.Domain.Entities
{
    public class Student : Person
    {
        public Student()
        {
            FamilyMembers = new HashSet<StudentFamilyMember>();
        }

        public ICollection<StudentFamilyMember> FamilyMembers { get; private set; }
    }
}

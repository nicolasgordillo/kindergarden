using Kindergarden.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    public class StudentFamilyMember
    {
        public int FamilyMemberId { get; set; }
        public Individual FamilyMember { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public FamilyMemberEnum Relationship { get; set; }
    }
}

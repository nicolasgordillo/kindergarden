using Kindergarden.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    public class Group
    {
        public Group()
        {
            //Initialized by DI or EF. It has private access so nobody can accidentally set it's value
            FamilyMembers = new HashSet<IndividualGroup>();
        }

        public int Id { get; set; }

        public string Description { get; set; } //Sala Rosa
        public int Year { get; set; }
        public string Section { get; set; } //1C
        public TimespanEnum TimeSpan { get; set; } //Turno mañana o tarde
        public bool Active { get; set; }

        public Individual Teacher { get; set; }
        public ICollection<IndividualGroup> FamilyMembers { get; private set; } //ICollection implements IEnumerable
    }
}

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
            FamilyMembers = new HashSet<Kin>();
            Notifications = new HashSet<Notification>();
        }

        public int Id { get; set; }

        public string Description { get; set; } //Sala Rosa
        public int Year { get; set; }
        public string Section { get; set; } //1C
        public string TimeSpan { get; set; } //Turno
        public bool Active { get; set; }

        public Teacher Teacher { get; set; }
        public ICollection<Kin> FamilyMembers { get; private set; } //ICollection implements IEnumerable
        public ICollection<Notification> Notifications { get; private set; }
    }
}

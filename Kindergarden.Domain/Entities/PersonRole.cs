using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    /// <summary>
    /// Esta clase relaciona personas mayores y roles, en una relación muchos a muchos.
    /// Lamentablemente, EF Core todavía no soporta relaciones many to many por convención, por lo que se debe realizar manualmente.
    /// </summary>
    public class PersonRole
    {
        public int PersonId { get; set; }
        public Individual Person { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}

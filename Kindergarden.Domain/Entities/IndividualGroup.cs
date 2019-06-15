using Kindergarden.Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    /// <summary>
    /// Esta clase relaciona personas mayores y grupos, en una relación muchos a muchos.
    /// Lamentablemente, EF Core todavía no soporta relaciones many to many por convención, por lo que se debe realizar manualmente.
    /// </summary>
    public class IndividualGroup
    {
        public int FamilyMemberId { get; set; }
        public Individual FamilyMember { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}

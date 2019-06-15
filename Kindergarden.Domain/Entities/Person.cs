using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    public abstract class Person
    {
        public int Id { get; set; }

        public DocumentType DocumentType { get; set; }
        public int DocumentId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    /* Esta clase representa un mensaje de los padres al jardín
     * Se encuentran limitados a ciertos tipos, no es un chat abierto.
     * Por ejemplo, se puede utilzar para enviar aviso de enfermedad (eventualmente un certificado), llegada tarde, etc.
     */
    public class Message
    {
        public int Id { get; set; }

        public MessageType Type { get; set; }
        public DateTime SentDate { get; set; }
        public string Text { get; set; }

        public bool Read { get; set; }
        public DateTime? ReadDate { get; set; }
        public bool Confirmed { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Individual SentTo { get; set; }
        public Individual SentBy { get; set; }
        public Student Regarding { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    /* This class represents a message from parents to kindergarden
     * They are limited to certain types of messages, not an open chat
     * For example, student sickness
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

        public Person SentTo { get; set; }
        public Person SentBy { get; set; }
        public Student Regarding { get; set; }
    }
}

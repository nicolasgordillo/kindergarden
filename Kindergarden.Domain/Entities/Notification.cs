using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    /* This class represents a notification from kindergarden to parents */
    public class Notification
    {
        public int Id { get; set; }

        public DateTime SentDate { get; set; }
        public string Text { get; set; }
    }
}

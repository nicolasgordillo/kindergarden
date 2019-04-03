using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    /* Esta clase representa una notificación del jardín a los padres. Tiene texto libre. */
    public class Notification
    {
        public int Id { get; set; }

        public DateTime SentDate { get; set; }
        public string Text { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Application.Notifications.Queries.GetNotificationList
{
    public class NotificationLookupModel
    {
        public int Id { get; set; }
        public DateTime SentDate { get; set; }
        public string Text { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Application.Notifications.Queries.GetNotificationDetail
{
    public class NotificationDetailViewModel
    {
        public int Id { get; set; }

        public DateTime SentDate { get; set; }
        public string Text { get; set; }
    }
}

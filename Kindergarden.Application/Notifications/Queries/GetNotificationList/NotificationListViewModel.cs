using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Application.Notifications.Queries.GetNotificationList
{
    public class NotificationListViewModel
    {
        public IList<NotificationLookupModel> Notifications { get; set; }
    }
}

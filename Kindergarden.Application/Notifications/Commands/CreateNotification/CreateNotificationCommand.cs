using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Application.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommand : IRequest<int>
    {
        public DateTime SentDate { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
}

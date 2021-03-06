﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Application.Notifications.Commands.CreateNotification
{
    public class CreatePublicNotificationCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public int PersonId { get; set; }
    }
}

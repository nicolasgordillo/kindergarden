﻿using MediatR;

namespace Kindergarden.Application.Notifications.Queries.GetNotificationDetail
{
    public class GetGroupDetailQuery : IRequest<GroupDetailViewModel>
    {
        public int Id { get; set; }
    }
}

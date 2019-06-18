using MediatR;

namespace Kindergarden.Application.Notifications.Queries.GetNotificationList
{
    public class GetNotificationListQuery : IRequest<NotificationListViewModel>
    {
        public int PersonId { get; set; }
    }
}

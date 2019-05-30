using MediatR;

namespace Kindergarden.Application.Notifications.Queries.GetNotificationDetail
{
    public class GetNotificationDetailQuery : IRequest<NotificationDetailViewModel>
    {
        public int Id { get; set; }
    }
}

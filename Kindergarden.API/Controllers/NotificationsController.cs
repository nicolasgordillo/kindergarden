using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kindergarden.Application.Notifications.Commands.CreateNotification;
using Kindergarden.Application.Notifications.Queries.GetNotificationList;
using Kindergarden.Application.Notifications.Queries.GetNotificationDetail;
using Microsoft.AspNetCore.Http;

namespace Kindergarden.API.Controllers
{
    public class NotificationsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<NotificationListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetNotificationListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationDetailViewModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetNotificationDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateNotificationCommand command)
        {
            var notificationId = await Mediator.Send(command);

            return Ok(notificationId);
        }
    }
}

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
        public async Task<ActionResult<NotificationListViewModel>> GetAll(int id)
        {
            return Ok(await Mediator.Send(new GetNotificationListQuery { PersonId = id }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotificationDetailViewModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetNotificationDetailQuery { Id = id }));
        }

        [HttpPost]
        [Route("public")]
        public async Task<ActionResult<int>> Create([FromBody] CreatePublicNotificationCommand command)
        {
            var notificationId = await Mediator.Send(command);

            return Ok(notificationId);
        }

        [HttpPost]
        [Route("group")]
        public async Task<ActionResult<int>> Create([FromBody] CreateGroupNotificationCommand command)
        {
            var notificationId = await Mediator.Send(command);

            return Ok(notificationId);
        }

        [HttpPost]
        [Route("private")]
        public async Task<ActionResult<int>> Create([FromBody] CreatePrivateNotificationCommand command)
        {
            var notificationId = await Mediator.Send(command);

            return Ok(notificationId);
        }
    }
}

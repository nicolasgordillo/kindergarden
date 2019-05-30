using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kindergarden.Application.Messages.Commands.CreateMessage;
using Kindergarden.Application.Messages.Queries.GetMessageList;
using Kindergarden.Application.Messages.Queries.GetMessageDetail;
using Microsoft.AspNetCore.Http;

namespace Kindergarden.API.Controllers
{
    public class MessagesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<MessageListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetMessageListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDetailViewModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetMessageDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateMessageCommand command)
        {
            var messageId = await Mediator.Send(command);

            return Ok(messageId);
        }
    }
}

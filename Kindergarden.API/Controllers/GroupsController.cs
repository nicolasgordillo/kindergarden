using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kindergarden.Application.Groups.Commands.CreateGroup;
using Kindergarden.Application.Groups.Commands.DeleteGroup;
using Kindergarden.Application.Groups.Commands.UpdateGroup;
using Kindergarden.Application.Groups.Queries.GetGroupList;
using Kindergarden.Application.Groups.Queries.GetGroupDetail;
using Microsoft.AspNetCore.Http;

namespace Kindergarden.API.Controllers
{
    public class GroupsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<GroupListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetGroupListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDetailViewModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetGroupDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateGroupCommand command)
        {
            var groupId = await Mediator.Send(command);

            return Ok(groupId);
        }

        [HttpPut]
        public async Task<ActionResult<GroupDto>> Update([FromBody] UpdateGroupCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteGroupCommand { Id = id });

            return NoContent();
        }
    }
}

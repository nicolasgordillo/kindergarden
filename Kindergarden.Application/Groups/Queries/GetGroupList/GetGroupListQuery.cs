using MediatR;

namespace Kindergarden.Application.Groups.Queries.GetGroupList
{
    public class GetGroupListQuery : IRequest<GroupListViewModel>
    {
        public int? PersonId { get; set; }
    }
}

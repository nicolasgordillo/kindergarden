using MediatR;

namespace Kindergarden.Application.Groups.Queries.GetGroupDetail
{
    public class GetGroupDetailQuery : IRequest<GroupDetailViewModel>
    {
        public int Id { get; set; }
    }
}

using MediatR;

namespace Kindergarden.Application.Messages.Queries.GetMessageList
{
    public class GetMessageListQuery : IRequest<MessageListViewModel>
    {
    }
}

using MediatR;

namespace Kindergarden.Application.Messages.Queries.GetMessageList
{
    public class GetMessageListQuery : IRequest<MessageListViewModel>
    {
        public int? SentBy { get; set; }

        public int? ReceivedBy { get; set; }
    }
}

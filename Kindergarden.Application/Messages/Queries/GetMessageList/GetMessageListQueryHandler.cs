using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kindergarden.Application.Interfaces;
using Kindergarden.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarden.Application.Messages.Queries.GetMessageList
{
    public class GetMessageListQueryHandler : IRequestHandler<GetMessageListQuery, MessageListViewModel>
    {
        private readonly IKindergardenContext _context;
        private readonly IMapper _mapper;

        public GetMessageListQueryHandler(IKindergardenContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MessageListViewModel> Handle(GetMessageListQuery request, CancellationToken cancellationToken)
        {
            List<Message> messages;

            messages = await _context.Messages.Where(x => (request.ReceivedBy == null || x.Id == request.ReceivedBy)
                    && (request.SentBy == null || x.Id == request.SentBy))
                .Include(x => x.Type).Include(x => x.Regarding).ToListAsync();

            var model = new MessageListViewModel
            {
                Messages = _mapper.Map<IEnumerable<MessageDto>>(messages)
            };

            return model;
        }
    }
}
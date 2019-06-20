using AutoMapper;
using Kindergarden.Application.Exceptions;
using Kindergarden.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kindergarden.Application.Messages.Queries.GetMessageDetail
{
    public class GetMessageDetailQueryHandler : IRequestHandler<GetMessageDetailQuery, MessageDetailViewModel>
    {
        private readonly IKindergardenContext _context;
        private readonly IMapper _mapper;

        public GetMessageDetailQueryHandler(IKindergardenContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MessageDetailViewModel> Handle(GetMessageDetailQuery request, CancellationToken cancellationToken)
        {
            var Message = _mapper.Map<MessageDetailViewModel>(await _context
                .Messages.Include(x => x.Type).Include(x => x.SentTo).Include(x => x.SentBy).Include(x => x.Regarding)
                .Where(x => x.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (Message == null)
            {
                throw new NotFoundException(nameof(Message), request.Id);
            }

            return Message;
        }
    }
}

using Kindergarden.Application.Interfaces;
using Kindergarden.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kindergarden.Application.Messages.Commands.CreateMessage
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, int>
    {
        private readonly IKindergardenContext _context;

        public CreateMessageCommandHandler(IKindergardenContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var entity = new Message
            {
                Regarding = _context.Students.FirstOrDefault(x => x.Id == request.RegardingId),
                SentBy = _context.Individuals.FirstOrDefault(x => x.Id == request.SentById),
                SentTo = _context.Individuals.FirstOrDefault(x => x.Id == request.SentToId),
                SentDate = DateTime.Now,
                Type = _context.MessageTypes.FirstOrDefault(x => x.Id == request.TypeId),
                Text = request.Text
            };

            _context.Messages.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

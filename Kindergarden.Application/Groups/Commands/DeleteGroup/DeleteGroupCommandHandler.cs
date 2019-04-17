using Kindergarden.Application.Exceptions;
using Kindergarden.Application.Interfaces;
using Kindergarden.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kindergarden.Application.Groups.Commands.DeleteGroup
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand>
    {
        private readonly IKindergardenContext _context;

        public DeleteGroupCommandHandler(IKindergardenContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Groups.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Group), request.Id);
            }

            _context.Groups.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

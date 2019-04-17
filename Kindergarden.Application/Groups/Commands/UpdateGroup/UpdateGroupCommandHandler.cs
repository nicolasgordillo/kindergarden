using Kindergarden.Application.Exceptions;
using Kindergarden.Application.Interfaces;
using Kindergarden.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kindergarden.Application.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommandHandler : IRequestHandler<DeleteGroupCommand, Unit>
    {
        private readonly IKindergardenContext _context;

        public UpdateGroupCommandHandler(IKindergardenContext context)
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

            entity.Id = request.Id;
            entity.Description = request.Description;
            entity.Year = request.Year;
            entity.Section = request.Section;
            entity.TimeSpan = request.TimeSpan;
            entity.Active = request.Active;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

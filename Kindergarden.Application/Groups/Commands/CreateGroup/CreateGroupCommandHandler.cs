using Kindergarden.Application.Interfaces;
using Kindergarden.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kindergarden.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, int>
    {
        private readonly IKindergardenContext _context;

        public CreateGroupCommandHandler(IKindergardenContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = new Group
            {
                Description = request.Description,
                Year = request.Year,
                Section = request.Section,
                TimeSpan = request.TimeSpan,
                Active = true
            };

            _context.Groups.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

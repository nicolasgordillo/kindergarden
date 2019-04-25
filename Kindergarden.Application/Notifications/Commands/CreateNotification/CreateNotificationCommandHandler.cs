using Kindergarden.Application.Interfaces;
using Kindergarden.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kindergarden.Application.Notifications.Commands.CreateNotification
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, int>
    {
        private readonly IKindergardenContext _context;

        public CreateNotificationCommandHandler(IKindergardenContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Notification
            {
                SentDate = DateTime.Now,
                Title = request.Title,
                Text = request.Text
            };

            _context.Notifications.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}

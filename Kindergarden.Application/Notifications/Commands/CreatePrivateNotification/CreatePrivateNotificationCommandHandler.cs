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
    public class CreatePrivateNotificationCommandHandler : IRequestHandler<CreatePrivateNotificationCommand, int>
    {
        private readonly IKindergardenContext _context;

        public CreatePrivateNotificationCommandHandler(IKindergardenContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePrivateNotificationCommand request, CancellationToken cancellationToken)
        {
            //Verificar si el usuario tiene algun rol que permita enviar notificaciones (eg. es docente). Reemplazar por auth.
            var user = _context.Individuals.FirstOrDefault(x => x.Id == request.PersonId);
            if (user == null || !user.Roles.Any(x => x.CanSendNotification))
                throw new Exception("User has not been authorized to make this request");

            var receiver = _context.Individuals.Where(x => x.Id == request.ReceiverId).FirstOrDefault();

            var entity = new Notification
            {
                SentDate = DateTime.Now,
                Title = request.Title,
                Text = request.Text,
                Type = Domain.Enumerations.NotificationTypeEnum.Private,
                Receiver = receiver
            };

            _context.Notifications.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //Agregar notificacion al receptor
            var personNotif = new PersonNotification()
            {
                ReceiverId = receiver.Id,
                NotificationId = entity.Id
            };

            entity.IndividualNotifications.Add(personNotif);

            return entity.Id;
        }
    }
}

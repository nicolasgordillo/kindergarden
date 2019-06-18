using Kindergarden.Application.Interfaces;
using Kindergarden.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kindergarden.Application.Notifications.Commands.CreateNotification
{
    public class CreateGroupNotificationCommandHandler : IRequestHandler<CreateGroupNotificationCommand, int>
    {
        private readonly IKindergardenContext _context;

        public CreateGroupNotificationCommandHandler(IKindergardenContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateGroupNotificationCommand request, CancellationToken cancellationToken)
        {
            //Verificar si el usuario tiene algun rol que permita enviar notificaciones (eg. es docente). Reemplazar por auth.
            var user = _context.Individuals.Include(x => x.Roles).ThenInclude(r => r.Role).FirstOrDefault(x => x.Id == request.PersonId);
            if (user == null || !user.Roles.Any(x => x.Role.CanSendNotification))
                throw new Exception("User has not been authorized to make this request");

            var group = _context.Groups.FirstOrDefault(x => x.Id == request.GroupId);
            var entity = new Notification
            {
                SentDate = DateTime.Now,
                Title = request.Title,
                Text = request.Text,
                Type = Domain.Enumerations.NotificationTypeEnum.Private,
                Group = group
            };

            _context.Notifications.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //Enviar notificacion a todos los individuos de este grupo
            var individuals = _context.Individuals.Where(x => x.Groups.Any(g => g.GroupId == request.GroupId)).Select(x => x.Id).ToList();
            foreach (var individual in individuals)
            {
                var personNotif = new PersonNotification()
                {
                    ReceiverId = individual,
                    NotificationId = entity.Id
                };

                entity.IndividualNotifications.Add(personNotif);
            }

            return entity.Id;
        }
    }
}

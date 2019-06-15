using AutoMapper;
using AutoMapper.QueryableExtensions;
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

namespace Kindergarden.Application.Notifications.Queries.GetNotificationList
{
    public class GetNotificationListQueryHandler : IRequestHandler<GetNotificationListQuery, NotificationListViewModel>
    {
        private readonly IKindergardenContext _context;
        private readonly IMapper _mapper;

        public GetNotificationListQueryHandler(IKindergardenContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NotificationListViewModel> Handle(GetNotificationListQuery request, CancellationToken cancellationToken)
        {
            ICollection<NotificationDto> notifications;

            if (request.PersonId.HasValue)
            {
                var person = await _context.Individuals.Where(x => x.Id == request.PersonId).Include(x => x.ReceivedNotifications).ThenInclude(x => x.Notification).FirstOrDefaultAsync();

                notifications = _mapper.Map<ICollection<NotificationDto>>(person?.ReceivedNotifications.OrderByDescending(x => x.Notification.SentDate));
            }
            else
            {
                notifications = _mapper.Map<ICollection<NotificationDto>>(await _context.Notifications.OrderByDescending(x => x.SentDate).ToListAsync(cancellationToken));
            }

            return new NotificationListViewModel
            {
                Notifications = notifications.ToList()
            };
        }
    }
}

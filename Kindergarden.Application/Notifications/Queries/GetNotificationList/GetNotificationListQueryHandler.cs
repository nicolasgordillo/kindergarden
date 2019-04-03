using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kindergarden.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kindergarden.Application.Notifications.Queries.GetNotificationList
{
    public class GetNotificationListQueryHandler : IRequestHandler<GetNotificationListQuery, NotificationListViewModel>
    {
        private readonly KindergardenContext _context;
        private readonly IMapper _mapper;

        public GetNotificationListQueryHandler(KindergardenContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NotificationListViewModel> Handle(GetNotificationListQuery request, CancellationToken cancellationToken)
        {
            return new NotificationListViewModel
            {
                Notifications = await _context.Notifications.ProjectTo<NotificationLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}

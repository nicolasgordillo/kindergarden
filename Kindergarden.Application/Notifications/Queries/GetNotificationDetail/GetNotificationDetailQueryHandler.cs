using AutoMapper;
using Kindergarden.Application.Exceptions;
using Kindergarden.Application.Interfaces;
using Kindergarden.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kindergarden.Application.Notifications.Queries.GetNotificationDetail
{
    public class GetNotificationDetailQueryHandler : IRequestHandler<GetNotificationDetailQuery, NotificationDetailViewModel>
    {
        private readonly IKindergardenContext _context;
        private readonly IMapper _mapper;

        public GetNotificationDetailQueryHandler(IKindergardenContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<NotificationDetailViewModel> Handle(GetNotificationDetailQuery request, CancellationToken cancellationToken)
        {
            var notification = _mapper.Map<NotificationDetailViewModel>(await _context
                .Notifications.Where(x => x.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (notification == null)
            {
                throw new NotFoundException(nameof(Notification), request.Id);
            }

            return notification;
        }
    }
}

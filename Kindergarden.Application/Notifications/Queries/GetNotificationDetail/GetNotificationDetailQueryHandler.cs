﻿using AutoMapper;
using Kindergarden.Application.Exceptions;
using Kindergarden.Application.Interfaces;
using Kindergarden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Kindergarden.Application.Notifications.Queries.GetNotificationDetail
{
    public class GetGroupDetailQueryHandler
    {
        private readonly IKindergardenContext _context;
        private readonly IMapper _mapper;

        public GetGroupDetailQueryHandler(IKindergardenContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GroupDetailViewModel> Handle(GetGroupDetailQuery request, CancellationToken cancellationToken)
        {
            var notification = _mapper.Map<GroupDetailViewModel>(await _context
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

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Kindergarden.Application.Interfaces;
using Kindergarden.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarden.Application.Groups.Queries.GetGroupList
{
    public class GetGroupListQueryHandler : IRequestHandler<GetGroupListQuery, GroupListViewModel>
    {
        private readonly IKindergardenContext _context;
        private readonly IMapper _mapper;

        public GetGroupListQueryHandler(IKindergardenContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GroupListViewModel> Handle(GetGroupListQuery request, CancellationToken cancellationToken)
        {
            List<Group> groups;

            if (request.PersonId.HasValue)
            {
                groups = _context.Groups.Where(x => x.FamilyMembers.FirstOrDefault(p => p.FamilyMemberId == request.PersonId) != null).Include(x => x.Teacher).ToList();
            } else
            {
                groups = await _context.Groups.OrderBy(p => p.Description).Include(p => p.Teacher).ToListAsync(cancellationToken);
            }

            var model = new GroupListViewModel
            {
                Groups = _mapper.Map<IEnumerable<GroupDto>>(groups)
            };

            return model;
        }
    }
}

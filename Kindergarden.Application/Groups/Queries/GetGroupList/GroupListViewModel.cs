using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Application.Groups.Queries.GetGroupList
{
    public class GroupListViewModel
    {
        public IEnumerable<GroupDto> Groups { get; set; }
    }
}

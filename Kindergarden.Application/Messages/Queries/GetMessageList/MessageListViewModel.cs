using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Application.Messages.Queries.GetMessageList
{
    public class MessageListViewModel
    {
        public IEnumerable<MessageDto> Messages { get; set; }
    }
}

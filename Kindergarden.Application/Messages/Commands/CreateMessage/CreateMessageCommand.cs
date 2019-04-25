using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Application.Messages.Commands.CreateMessage
{
    public class CreateMessageCommand : IRequest<int>
    {
        public int TypeId { get; set; }
        public string Text { get; set; }

        public int SentToId { get; set; }
        public int SentById { get; set; }
        public int RegardingId { get; set; }
    }
}

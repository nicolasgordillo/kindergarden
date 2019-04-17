﻿using MediatR;

namespace Kindergarden.Application.Messages.Queries.GetMessageDetail
{
    public class GetMessageDetailQuery : IRequest<MessageDetailViewModel>
    {
        public int Id { get; set; }
    }
}

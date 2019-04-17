﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Application.Groups.Commands.DeleteGroup
{
    public class DeleteGroupCommand : IRequest
    {
        public int Id { get; set; }
    }
}

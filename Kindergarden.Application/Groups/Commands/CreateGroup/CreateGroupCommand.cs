using Kindergarden.Domain.Enumerations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Application.Groups.Commands.CreateGroup
{
    public class CreateGroupCommand : IRequest<int>
    {
        public string Description { get; set; } //Sala Rosa
        public int Year { get; set; }
        public string Section { get; set; } //1C
        public TimespanEnum TimeSpan { get; set; } //Turno
        public bool Active { get; set; }
    }
}

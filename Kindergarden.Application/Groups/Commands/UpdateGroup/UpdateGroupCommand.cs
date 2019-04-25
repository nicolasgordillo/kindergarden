using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Application.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommand : IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; } //Sala Rosa
        public int Year { get; set; }
        public string Section { get; set; } //1C
        public string TimeSpan { get; set; } //Turno
        public bool Active { get; set; }
    }
}

using AutoMapper;
using Kindergarden.Application.Interfaces.Mapping;
using Kindergarden.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Application.Messages.Queries.GetMessageList
{
    public class MessageDto : IHaveCustomMappings
    {
        public int Id { get; set; }

        public string TypeDescription { get; set; }
        public DateTime SentDate { get; set; }
        public string Text { get; set; }

        public bool Read { get; set; }
        public DateTime? ReadDate { get; set; }
        public bool Confirmed { get; set; }
        public DateTime? ConfirmedDate { get; set; }

        public string RegardingStudentFullName { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Message, MessageDto>()
                .ForMember(pDTO => pDTO.TypeDescription, opt => opt.MapFrom(m => m.Type != null ? m.Type.Description : string.Empty))
                .ForMember(pDTO => pDTO.RegardingStudentFullName, opt => opt.MapFrom(m => m.Regarding != null ? m.Regarding.FirstName + " " + m.Regarding.LastName : string.Empty));
        }
    }
}

using AutoMapper;
using Kindergarden.Application.Interfaces.Mapping;
using Kindergarden.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Application.Messages.Queries.GetMessageDetail
{
    public class MessageDetailViewModel : IHaveCustomMappings
    {
        public int Id { get; set; }

        public string TypeDescription { get; set; }
        public DateTime SentDate { get; set; }
        public string Text { get; set; }

        public bool Read { get; set; }
        public DateTime? ReadDate { get; set; }
        public bool Confirmed { get; set; }
        public DateTime? ConfirmedDate { get; set; }

        public Individual SentToFullName { get; set; }
        public Individual SentByFullName { get; set; }
        public Student RegardingStudentFullName { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Message, MessageDetailViewModel>()
                .ForMember(pDTO => pDTO.TypeDescription, opt => opt.MapFrom(m => m.Type != null ? m.Type.Description : string.Empty))
                .ForMember(pDTO => pDTO.SentToFullName, opt => opt.MapFrom(m => m.SentTo != null ? m.SentTo.FirstName + " " + m.SentTo.LastName : string.Empty))
                .ForMember(pDTO => pDTO.SentByFullName, opt => opt.MapFrom(m => m.SentBy != null ? m.SentBy.FirstName + " " + m.SentBy.LastName : string.Empty))
                .ForMember(pDTO => pDTO.RegardingStudentFullName, opt => opt.MapFrom(m => m.Regarding != null ? m.Regarding.FirstName + " " + m.Regarding.LastName : string.Empty));
        }
    }
}

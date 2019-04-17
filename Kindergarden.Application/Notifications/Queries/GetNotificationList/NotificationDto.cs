using AutoMapper;
using Kindergarden.Application.Interfaces.Mapping;
using Kindergarden.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Application.Notifications.Queries.GetNotificationList
{
    public class NotificationDto: IHaveCustomMappings
    {
        public int NotificationId { get; set; }
        public DateTime SentDate { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public bool Read { get; set; }
        public bool Confirmed { get; set; }
        public bool Deleted { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<PersonNotification, NotificationDto>()
                .ForMember(pDTO => pDTO.SentDate, opt => opt.MapFrom(m => m.Notification.SentDate))
                .ForMember(pDTO => pDTO.Title, opt => opt.MapFrom(m => m.Notification.Title))
                .ForMember(pDTO => pDTO.Text, opt => opt.MapFrom(m => m.Notification.Text))
                .ForMember(pDTO => pDTO.NotificationId, opt => opt.MapFrom(m => m.Notification.Id));
        }
    }
}

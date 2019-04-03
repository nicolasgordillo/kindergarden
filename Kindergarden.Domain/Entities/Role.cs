using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //Puede enviar mensajes predefinidos
        public bool CanSendMessage { get; set; }

        //Puede enviar notificaciones (texto libre)
        public bool CanSendNotification { get; set; }
    }
}

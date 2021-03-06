﻿using Kindergarden.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kindergarden.Application.Interfaces
{
    public interface IKindergardenContext
    {
        DbSet<Group> Groups { get; set; }

        DbSet<Notification> Notifications { get; set; }
        DbSet<Message> Messages { get; set; }

        DbSet<Individual> Individuals { get; set; }
        DbSet<Student> Students { get; set; }

        DbSet<MessageType> MessageTypes { get; set; }
        DbSet<DocumentType> DocumentTypes { get; set; }

        DbSet<Role> Roles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

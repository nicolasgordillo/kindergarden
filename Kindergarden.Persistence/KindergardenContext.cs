using Kindergarden.Application.Interfaces;
using Kindergarden.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kindergarden.Persistence
{
    public class KindergardenContext : DbContext, IKindergardenContext
    {
        public KindergardenContext(DbContextOptions<KindergardenContext> options)
            : base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }

        //No se puede acceder a todas las personas ya que no se crean objetos de tipo Persona directamente
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KindergardenContext).Assembly);
        }
    }
}

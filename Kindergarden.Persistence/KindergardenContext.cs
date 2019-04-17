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

        public DbSet<Person> Persons { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KindergardenContext).Assembly);
        }
    }
}

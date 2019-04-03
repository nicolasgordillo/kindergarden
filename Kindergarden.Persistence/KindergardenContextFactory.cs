using Kindergarden.Persistence.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Kindergarden.Persistence
{
    public class KindergardenContextFactory : DesignTimeDbContextFactoryBase<KindergardenContext>
    {
        protected override KindergardenContext CreateNewInstance(DbContextOptions<KindergardenContext> options)
        {
            return new KindergardenContext(options);
        }
    }
}

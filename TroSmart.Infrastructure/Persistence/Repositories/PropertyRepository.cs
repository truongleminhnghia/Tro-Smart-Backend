using TroSmart.Domain.Entities;
using TroSmart.Domain.Interfaces;
using TroSmart.Infrastructure.Persistence.Base;
using TroSmart.Infrastructure.Persistence.Context;

namespace TroSmart.Infrastructure.Persistence.Repositories
{
    public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(TroSmartDbContext context) : base(context)
        {
        }
    }
}
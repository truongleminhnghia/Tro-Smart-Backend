using TroSmart.Domain.Entities;
using TroSmart.Domain.Interfaces;
using TroSmart.Infrastructure.Persistence.Base;
using TroSmart.Infrastructure.Persistence.Context;

namespace TroSmart.Infrastructure.Persistence.Repositories
{
    public class ListingRepository : GenericRepository<Listing>, IListingRepository
    {
        public ListingRepository(TroSmartDbContext context) : base(context)
        {
        }
    }
}
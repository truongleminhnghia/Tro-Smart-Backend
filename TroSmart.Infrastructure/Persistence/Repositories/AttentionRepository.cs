
using TroSmart.Domain.Entities;
using TroSmart.Domain.Interfaces;
using TroSmart.Infrastructure.Persistence.Base;
using TroSmart.Infrastructure.Persistence.Context;

namespace TroSmart.Infrastructure.Persistence.Repositories
{
    public class AttentionRepository : GenericRepository<Attention>, IAttentionRepository
    {
        public AttentionRepository(TroSmartDbContext context) : base(context)
        {
        }
    }
}
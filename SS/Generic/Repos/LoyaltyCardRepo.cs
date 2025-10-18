using Microsoft.EntityFrameworkCore;
using SS.Generic.Interfaces;
using SS.Models;

namespace SS.Generic.Repos
{
    public class LoyaltyCardRepo : Generic<LoyaltyCard>, ILoyaltyCard
    {
        public LoyaltyCardRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<LoyaltyCard>> GetLoyalty()
        {
          return await _context.loyaltyCards.Include(x=>x.Customer).Where(x=>x.Blalnce > 0).OrderByDescending(x=>x.Customer.Name).ToListAsync();
        }
    }
}

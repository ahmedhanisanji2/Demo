using Microsoft.EntityFrameworkCore;
using SS.Generic.Interfaces;
using SS.Models;

namespace SS.Generic.Repos
{
    public class CustomerRepo : Generic<Customer>, ICustomer
    {
        public CustomerRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Customer>> Customers()
        {
            return await _context.customers.Include(x=>x.artPieces).Include(x=>x.LoyaltyCard).OrderByDescending(x=>((decimal)x.artPieces.Sum(x=>x.Price))).ToListAsync();
        }

        public async Task<IEnumerable<Customer>> CustomersUnique()
        {
            return await _context.customers.Include(x => x.artPieces).Where(x => x.artPieces.Count() > 0).Distinct().ToListAsync();
        }
    }
}

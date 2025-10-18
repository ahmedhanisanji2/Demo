using Microsoft.EntityFrameworkCore;
using SS.Generic.Interfaces;
using SS.Models;

namespace SS.Generic.Repos
{
    public class CategoryRepo : Generic<Category>, ICategory
    {
        public CategoryRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> categories()
        {
           return await _context.categories.Include(x=>x.artPieces).OrderByDescending(x=>x.artPieces.Count()).ToListAsync();
        }

        public async Task<bool> DeleteIF(int id)
        {
            var cat = await _context.categories.Include(x=>x.artPieces).FirstOrDefaultAsync(x=>x.Id == id); 
            if(cat.artPieces.Count == 0)
            {
               return false;
            }
            return true;

        }

        public async Task<IEnumerable<Category>> SummaryCat()
        {
            return await _context.categories.Include(x => x.artPieces).ThenInclude(x => x.Customer).ThenInclude(x => x.LoyaltyCard).OrderByDescending(x=>x.artPieces.Count()).ToListAsync();
        }
    }
}

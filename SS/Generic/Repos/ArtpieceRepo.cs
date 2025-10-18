using Microsoft.EntityFrameworkCore;
using SS.Generic.Interfaces;
using SS.Models;

namespace SS.Generic.Repos
{
    public class ArtpieceRepo : Generic<ArtPiece>, IArtPiece
    {
        public ArtpieceRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ArtPiece>> GetAlls()
        {
            return await _context.artPieces.Include(x=>x.Customer).Include(x=>x.categories).OrderByDescending(x=>x.Price).ToListAsync();
        }
    }
}

using SS.Models;

namespace SS.Generic.Interfaces
{
    public interface IArtPiece : IGeneric<ArtPiece>
    {
        Task<IEnumerable<ArtPiece>> GetAlls();
     
    }
}

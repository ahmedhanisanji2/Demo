using SS.Models;

namespace SS.Generic.Interfaces
{
    public interface ILoyaltyCard : IGeneric<LoyaltyCard>
    {
        Task<IEnumerable<LoyaltyCard>> GetLoyalty();
    }
}

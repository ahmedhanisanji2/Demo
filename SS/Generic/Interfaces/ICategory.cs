using SS.Models;

namespace SS.Generic.Interfaces
{
    public interface ICategory : IGeneric<Category>
    {
        Task<IEnumerable<Category>> categories();
        Task<IEnumerable<Category>> SummaryCat();
        Task<bool> DeleteIF(int id);
    }
}

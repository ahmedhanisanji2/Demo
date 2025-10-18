namespace SS.Generic
{
    public interface IGeneric<T> where T : class
    {

        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        Task AddAsync(T entity);

        void DeleteAsync(T entity);

        void UpdateAsync(T entity);

        Task SaveChangesAsync();

    }
}

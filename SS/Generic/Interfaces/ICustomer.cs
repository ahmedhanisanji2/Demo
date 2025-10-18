using SS.Models;

namespace SS.Generic.Interfaces
{
    public interface ICustomer :IGeneric<Customer>
    {
        Task<IEnumerable<Customer>> Customers();
        Task<IEnumerable<Customer>> CustomersUnique();

    }
}

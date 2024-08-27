using Store.Models.Models;

namespace Store.DataAccess.Repository
{
    public interface ICustomerRepository
    {
        Task<List<CCustomer>> GetCustomersAsync();
        //Task<PagingResult<CCustomer>> GetCustomersPageAsync(int skip, int take);
        Task<CCustomer> GetCustomerAsync(int id);

        Task<CCustomer> InsertCustomerAsync(CCustomer customer);
        Task<bool> UpdateCustomerAsync(CCustomer customer);
        Task<bool> DeleteCustomerAsync(int id);
    }
}

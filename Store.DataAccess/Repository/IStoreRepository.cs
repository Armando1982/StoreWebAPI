using Store.Models.Models;

namespace Store.DataAccess.Repository
{
    public interface IStoreRepository
    {
        Task<List<CStore>> GetStoresAsync();
        //Task<PagingResult<CCustomer>> GetCustomersPageAsync(int skip, int take);
        Task<CStore> GetStoreAsync(int id);

        Task<CStore> InsertStoreAsync(CStore store);
        Task<bool> UpdateStoreAsync(CStore store);
        Task<bool> DeleteStoreAsync(int id);
    }
}

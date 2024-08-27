using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.DataAccess.Data;
using Store.Models.Models;

namespace Store.DataAccess.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly StoreDbContext _storeDbContext;
        private readonly ILogger _loggerFactory;

        public StoreRepository(StoreDbContext storeDbContext, ILoggerFactory loggerFactory)
        {
            _storeDbContext = storeDbContext;
            _loggerFactory = loggerFactory.CreateLogger("StoresRepository");
        }
        public async Task<bool> DeleteStoreAsync(int id)
        {
            var Store = await _storeDbContext.Stores.SingleOrDefaultAsync(c => c.StoreId == id);
            _storeDbContext.Remove(Store);

            try
            {
                return (await _storeDbContext.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _loggerFactory.LogError($"Error in {nameof(DeleteStoreAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<CStore> GetStoreAsync(int id)
        {
            return await _storeDbContext.Stores.SingleOrDefaultAsync(c => c.StoreId == id);
        }

        public async Task<List<CStore>> GetStoresAsync()
        {
            return await _storeDbContext.Stores.OrderBy(c => c.StoreName).ToListAsync();
        }

        public async Task<CStore> InsertStoreAsync(CStore Store)
        {
            _storeDbContext.Add(Store);
            try
            {
                await _storeDbContext.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError($"Error in {nameof(InsertStoreAsync)}: " + exp.Message);
            }

            return Store;

        }

        public async Task<bool> UpdateStoreAsync(CStore Store)
        {
            _storeDbContext.Stores.Attach(Store);
            try
            {
                return (await _storeDbContext.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _loggerFactory.LogError($"Error in {nameof(UpdateStoreAsync)}: " + exp.Message);
            }
            return false;

        }
    }
}

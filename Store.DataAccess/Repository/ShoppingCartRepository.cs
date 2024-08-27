using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.DataAccess.Data;
using Store.Models.Models;

namespace Store.DataAccess.Repository
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly StoreDbContext _storeDbContext;
        private readonly ILogger _loggerFactory;

        public ShoppingCartRepository(StoreDbContext storeDbContext, ILoggerFactory loggerFactory)
        {
            _storeDbContext = storeDbContext;
            _loggerFactory = loggerFactory.CreateLogger("ShoppingCartRepository");
        }
        public async Task<bool> DeleteGetShoppingCartAsync(int id)
        {
            var shopingCart = await _storeDbContext.ShopingCarts.SingleOrDefaultAsync(c => c.Id == id);
            _storeDbContext.Remove(shopingCart);

            try
            {
                return (await _storeDbContext.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _loggerFactory.LogError($"Error in {nameof(DeleteGetShoppingCartAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<CShopingCart> GetShoppingCartAsync(int id)
        {
            return await _storeDbContext.ShopingCarts.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<CShopingCart>> GetShoppingCartsAsync()
        {
            return await _storeDbContext.ShopingCarts.OrderBy(c => c.Id).ToListAsync();
        }

        public async Task<CShopingCart> InsertShoppingCartsAsync(CShopingCart shopingCart)
        {
            _storeDbContext.Add(shopingCart);
            try
            {
                await _storeDbContext.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError($"Error in {nameof(InsertShoppingCartsAsync)}: " + exp.Message);
            }

            return shopingCart;

        }

        public async Task<bool> UpdateGetShoppingCartAsync(CShopingCart shopingCart)
        {
            _storeDbContext.ShopingCarts.Attach(shopingCart);
            try
            {
                return (await _storeDbContext.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _loggerFactory.LogError($"Error in {nameof(UpdateGetShoppingCartAsync)}: " + exp.Message);
            }
            return false;

        }
    }
}

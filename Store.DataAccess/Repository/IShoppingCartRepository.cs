using Store.Models.Models;

namespace Store.DataAccess.Repository
{
    public interface IShoppingCartRepository
    {
        Task<List<CShopingCart>> GetShoppingCartsAsync();
        //Task<PagingResult<CShopingCart>> GetarticlesPageAsync(int skip, int take);
        Task<CShopingCart> GetShoppingCartAsync(int id);

        Task<CShopingCart> InsertShoppingCartsAsync(CShopingCart shopingCart);
        Task<bool> UpdateGetShoppingCartAsync(CShopingCart shopingCart);
        Task<bool> DeleteGetShoppingCartAsync(int id);
    }
}

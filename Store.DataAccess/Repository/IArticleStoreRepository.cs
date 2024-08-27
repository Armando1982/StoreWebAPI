using Store.Models.Models;

namespace Store.DataAccess.Repository
{
    public interface IArticleStoreRepository
    {
        Task<List<CStoresArticles>> GetArticlesStoresAsync();
        //Task<PagingResult<Carticle>> GetarticlesPageAsync(int skip, int take);
        Task<CStoresArticles> GetArticleStoreAsync(int id);

        Task<CStoresArticles> InsertArticleStoreAsync(CStoresArticles storesArticle);
        Task<bool> UpdateArticleStoreAsync(CStoresArticles storesArticle);
        Task<bool> DeleteArticleStoreAsync(int id);
    }
}

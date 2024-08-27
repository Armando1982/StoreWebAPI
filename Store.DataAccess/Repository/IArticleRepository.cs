using Store.Models.Models;

namespace Store.DataAccess.Repository
{
    public interface IArticleRepository
    {
        Task<List<CArticle>> GetArticlesAsync();
        //Task<PagingResult<Carticle>> GetarticlesPageAsync(int skip, int take);
        Task<CArticle> GetArticleAsync(int id);

        Task<CArticle> InsertArticleAsync(CArticle article);
        Task<bool> UpdateArticleAsync(CArticle article);
        Task<bool> DeleteArticleAsync(int id);
    }
}

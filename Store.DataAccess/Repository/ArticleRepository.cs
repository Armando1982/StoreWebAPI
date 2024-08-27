using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.DataAccess.Data;
using Store.Models.Models;

namespace Store.DataAccess.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly StoreDbContext _storeDbContext;
        private readonly ILogger _loggerFactory;

        public ArticleRepository(StoreDbContext storeDbContext, ILoggerFactory loggerFactory)
        {
            _storeDbContext = storeDbContext;
            _loggerFactory = loggerFactory.CreateLogger("ArticlesRepository");
        }
        public async Task<bool> DeleteArticleAsync(int id)
        {
            var article = await _storeDbContext.Articles.SingleOrDefaultAsync(c => c.ArticleId == id);
            _storeDbContext.Remove(article);

            try
            {
                return (await _storeDbContext.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _loggerFactory.LogError($"Error in {nameof(DeleteArticleAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<CArticle> GetArticleAsync(int id)
        {
            return await _storeDbContext.Articles.SingleOrDefaultAsync(c => c.ArticleId == id);
        }

        public async Task<List<CArticle>> GetArticlesAsync()
        {
            return await _storeDbContext.Articles.OrderBy(c => c.ArticleId).ToListAsync();
        }

        public async Task<CArticle> InsertArticleAsync(CArticle article)
        {
            _storeDbContext.Add(article);
            try
            {
                await _storeDbContext.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError($"Error in {nameof(InsertArticleAsync)}: " + exp.Message);
            }

            return article;

        }

        public async Task<bool> UpdateArticleAsync(CArticle article)
        {
            _storeDbContext.Articles.Attach(article);
            try
            {
                return (await _storeDbContext.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _loggerFactory.LogError($"Error in {nameof(UpdateArticleAsync)}: " + exp.Message);
            }
            return false;

        }
    }
}

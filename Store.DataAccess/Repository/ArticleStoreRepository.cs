using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.DataAccess.Data;
using Store.Models.Models;

namespace Store.DataAccess.Repository
{
    public class ArticleStoreRepository : IArticleStoreRepository
    {
        private readonly StoreDbContext _storeDbContext;
        private readonly ILogger _loggerFactory;

        public ArticleStoreRepository(StoreDbContext storeDbContext, ILoggerFactory loggerFactory)
        {
            _storeDbContext = storeDbContext;
            _loggerFactory = loggerFactory.CreateLogger("ArticleStoreRepository");
        }
        public async Task<bool> DeleteArticleStoreAsync(int id)
        {
            var article = await _storeDbContext.StoresArticles.SingleOrDefaultAsync(c => c.Id == id);
            _storeDbContext.Remove(article);

            try
            {
                return (await _storeDbContext.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _loggerFactory.LogError($"Error in {nameof(DeleteArticleStoreAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<CStoresArticles> GetArticleStoreAsync(int id)
        {
            return await _storeDbContext.StoresArticles.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<CStoresArticles>> GetArticlesStoresAsync()
        {
            return await _storeDbContext.StoresArticles.OrderBy(c => c.ArticleId).ToListAsync();
        }

        public async Task<CStoresArticles> InsertArticleStoreAsync(CStoresArticles article)
        {
            _storeDbContext.Add(article);
            try
            {
                await _storeDbContext.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError($"Error in {nameof(InsertArticleStoreAsync)}: " + exp.Message);
            }

            return article;

        }

        public async Task<bool> UpdateArticleStoreAsync(CStoresArticles article)
        {
            _storeDbContext.StoresArticles.Attach(article);
            try
            {
                return (await _storeDbContext.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _loggerFactory.LogError($"Error in {nameof(UpdateArticleStoreAsync)}: " + exp.Message);
            }
            return false;

        }
    }
}

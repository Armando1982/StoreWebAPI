using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.DataAccess.Repository;
using Store.Models.Models;
using StoreWebAPI.Infrastructure;

namespace StoreWebAPI.APIs
{
    [Route("api/StoreArticles")]
    [Authorize]
    [ApiController]
    public class ArticleStoreController : Controller
    {
        private IArticleStoreRepository _articleStoreRepository;
        private ILogger _logger;

        public ArticleStoreController(IArticleStoreRepository articleStoreRepository, ILoggerFactory loggerFactory)
        {
            _articleStoreRepository = articleStoreRepository;
            _logger = loggerFactory.CreateLogger(nameof(ArticleStoreController));
        }
        // GET api/customers
        [HttpGet]
        [NoCache]
        [ProducesResponseType(typeof(List<CStoresArticles>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> ArticlesStores()
        {
            try
            {
                var articles = await _articleStoreRepository.GetArticlesStoresAsync();
                //return Ok(customers);
                return Ok(new { value = articles });

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // GET api/customers/5
        [HttpGet("{id}", Name = "GetArticlesStoreRoute")]
        [NoCache]
        [ProducesResponseType(typeof(CStoresArticles), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> Article(int id)
        {
            try
            {
                var article = await _articleStoreRepository.GetArticleStoreAsync(id);
                //return Ok(customer);
                return Ok(new ApiResponse { StoresArticles = article });
                //return Ok( new { value = customer });
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // POST api/customers
        [HttpPost]
        // [ValidateAntiForgeryToken]
        [ProducesResponseType(typeof(ApiResponse), 201)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> CreateArticle([FromBody] CStoresArticles article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse { Status = false, ModelState = ModelState });
            }

            try
            {
                var newArticle = await _articleStoreRepository.InsertArticleStoreAsync(article);
                if (newArticle == null)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return CreatedAtRoute("GetCustomerRoute", new { id = newArticle.Id },
                        new ApiResponse { Status = true, StoresArticles = newArticle });
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        // [ValidateAntiForgeryToken]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> UpdateArticle(int id, [FromBody] CStoresArticles article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse { Status = false, ModelState = ModelState });
            }

            try
            {
                var status = await _articleStoreRepository.UpdateArticleStoreAsync(article);
                if (!status)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return Ok(new ApiResponse { Status = true, StoresArticles = article });
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        // [ValidateAntiForgeryToken]
        [ProducesResponseType(typeof(ApiResponse), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            try
            {
                var status = await _articleStoreRepository.DeleteArticleStoreAsync(id);
                if (!status)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return Ok(new ApiResponse { Status = true });
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

    }
}

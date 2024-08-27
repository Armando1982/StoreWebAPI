using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.DataAccess.Repository;
using Store.Models.Models;
using StoreWebAPI.Infrastructure;

namespace StoreWebAPI.APIs
{
    [Route("api/Articles")]
    [Authorize]
    [ApiController]
    public class ArticleController : Controller
    {
        private IArticleRepository _articleRepository;
        private ILogger _logger;

        public ArticleController(IArticleRepository articleRepository, ILoggerFactory loggerFactory)
        {
            _articleRepository = articleRepository;
            _logger = loggerFactory.CreateLogger(nameof(ArticleController));
        }
        // GET api/customers
        [HttpGet]
        [NoCache]
        [ProducesResponseType(typeof(List<CArticle>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> Articles()
        {
            try
            {
                var articles = await _articleRepository.GetArticlesAsync();
                //return Ok(customers);
                return Ok(new { value = articles });

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        //// GET api/customers/page/10/10
        //[HttpGet("page/{skip}/{take}")]
        //[NoCache]
        //[ProducesResponseType(typeof(List<Customer>), 200)]
        //[ProducesResponseType(typeof(ApiResponse), 400)]
        //public async Task<ActionResult> CustomersPage(int skip, int take)
        //{
        //    try
        //    {
        //        var pagingResult = await _CustomersRepository.GetCustomersPageAsync(skip, take);
        //        Response.Headers.Add("X-InlineCount", pagingResult.TotalRecords.ToString());
        //        return Ok(pagingResult.Records);
        //    }
        //    catch (Exception exp)
        //    {
        //        _Logger.LogError(exp.Message);
        //        return BadRequest(new ApiResponse { Status = false });
        //    }
        //}

        // GET api/customers/5
        [HttpGet("{id}", Name = "GetArticlesRoute")]
        [NoCache]
        [ProducesResponseType(typeof(CArticle), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> Article(int id)
        {
            try
            {
                var article = await _articleRepository.GetArticleAsync(id);
                //return Ok(customer);
                return Ok(new ApiResponse { Article = article });
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
        public async Task<ActionResult> CreateArticle([FromBody] CArticle article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse { Status = false, ModelState = ModelState });
            }

            try
            {
                var newArticle = await _articleRepository.InsertArticleAsync(article);
                if (newArticle == null)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return CreatedAtRoute("GetArticleRoute", new { id = newArticle.ArticleId },
                        new ApiResponse { Status = true, Article = newArticle });
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
        public async Task<ActionResult> UpdateArticle(int id, [FromBody] CArticle article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse { Status = false, ModelState = ModelState });
            }

            try
            {
                var status = await _articleRepository.UpdateArticleAsync(article);
                if (!status)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return Ok(new ApiResponse { Status = true, Article = article });
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
                var status = await _articleRepository.DeleteArticleAsync(id);
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

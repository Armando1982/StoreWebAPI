using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.DataAccess.Repository;
using Store.Models.Models;
using StoreWebAPI.Infrastructure;

namespace StoreWebAPI.APIs
{
    [Route("api/ShoppingCarts")]
    [Authorize]
    [ApiController]
    public class ShoppingCartController : Controller
    {
        private IShoppingCartRepository _shoppingCartRepository;
        private ILogger _logger;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, ILoggerFactory loggerFactory)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _logger = loggerFactory.CreateLogger(nameof(ShoppingCartController));
        }
        // GET api/customers
        [HttpGet]
        [NoCache]
        [ProducesResponseType(typeof(List<CShopingCart>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> ShoppingCarts()
        {
            try
            {
                var shoppingCarts = await _shoppingCartRepository.GetShoppingCartsAsync();
                //return Ok(customers);
                return Ok(new { value = shoppingCarts });

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // GET api/customers/5
        [HttpGet("{id}", Name = "GetShoppingCartRoute")]
        [NoCache]
        [ProducesResponseType(typeof(CShopingCart), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> GetShoppingCartAsync(int id)
        {
            try
            {
                var shoppingCart = await _shoppingCartRepository.GetShoppingCartAsync(id);
                //return Ok(customer);
                return Ok(new ApiResponse { ShopingCart = shoppingCart });
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
        public async Task<ActionResult> CreateArticle([FromBody] CShopingCart shopingCart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse { Status = false, ModelState = ModelState });
            }

            try
            {
                var newArticle = await _shoppingCartRepository.InsertShoppingCartsAsync(shopingCart);
                if (newArticle == null)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return CreatedAtRoute("GetShoppingCartRoute", new { id = newArticle.Id },
                        new ApiResponse { Status = true, ShopingCart = newArticle });
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
        public async Task<ActionResult> UpdateArticle(int id, [FromBody] CShopingCart shopingCart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse { Status = false, ModelState = ModelState });
            }

            try
            {
                var status = await _shoppingCartRepository.UpdateGetShoppingCartAsync(shopingCart);
                if (!status)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return Ok(new ApiResponse { Status = true, ShopingCart = shopingCart });
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
                var status = await _shoppingCartRepository.DeleteGetShoppingCartAsync(id);
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

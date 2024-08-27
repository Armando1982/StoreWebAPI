using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.DataAccess.Repository;
using Store.Models.Models;
using StoreWebAPI.Infrastructure;

namespace StoreWebAPI.APIs
{
    [Route("api/Stores")]
    [Authorize]
    [ApiController]
    public class StoreController : Controller
    {
        private IStoreRepository _storeRepository;
        private ILogger _logger;

        public StoreController(IStoreRepository storeRepository, ILoggerFactory loggerFactory)
        {
            _storeRepository = storeRepository;
            _logger = loggerFactory.CreateLogger(nameof(StoreController));
        }
        // GET api/customers
        [HttpGet]
        [NoCache]
        [ProducesResponseType(typeof(List<CStore>), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> Stores()
        {
            try
            {
                var stores = await _storeRepository.GetStoresAsync();
                //return Ok(customers);
                return Ok(new { value = stores });

            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }
        }

        // GET api/customers/5
        [HttpGet("{id}", Name = "GetStoreRoute")]
        [NoCache]
        [ProducesResponseType(typeof(CStore), 200)]
        [ProducesResponseType(typeof(ApiResponse), 400)]
        public async Task<ActionResult> Customers(int id)
        {
            try
            {
                var store = await _storeRepository.GetStoreAsync(id);
                //return Ok(customer);
                return Ok(new ApiResponse { Store = store });
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
        public async Task<ActionResult> CreateStore([FromBody] CStore store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse { Status = false, ModelState = ModelState });
            }

            try
            {
                var newStore = await _storeRepository.InsertStoreAsync(store);
                if (newStore == null)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return CreatedAtRoute("GetCustomerRoute", new { id = newStore.StoreId },
                        new ApiResponse { Status = true, Store = newStore });
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
        public async Task<ActionResult> UpdateStore(int id, [FromBody] CStore store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse { Status = false, ModelState = ModelState });
            }

            try
            {
                var status = await _storeRepository.UpdateStoreAsync(store);
                if (!status)
                {
                    return BadRequest(new ApiResponse { Status = false });
                }
                return Ok(new ApiResponse { Status = true, Store = store });
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
        public async Task<ActionResult> DeleteStore(int id)
        {
            try
            {
                var status = await _storeRepository.DeleteStoreAsync(id);
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

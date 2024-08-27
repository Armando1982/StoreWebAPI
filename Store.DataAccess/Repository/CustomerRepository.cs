using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.DataAccess.Data;
using Store.Models.Models;

namespace Store.DataAccess.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreDbContext _storeDbContext;
        private readonly ILogger _loggerFactory;

        public CustomerRepository(StoreDbContext storeDbContext, ILoggerFactory loggerFactory)
        {
            _storeDbContext = storeDbContext;
            _loggerFactory = loggerFactory.CreateLogger("CustomersRepository");
        }
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await _storeDbContext.Customers.SingleOrDefaultAsync(c => c.CustomerId == id);
            _storeDbContext.Remove(customer);

            try
            {
                return (await _storeDbContext.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _loggerFactory.LogError($"Error in {nameof(DeleteCustomerAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<CCustomer> GetCustomerAsync(int id)
        {
            return await _storeDbContext.Customers.SingleOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task<List<CCustomer>> GetCustomersAsync()
        {
            return await _storeDbContext.Customers.OrderBy(c => c.CustomerName).ToListAsync();
        }

        public async Task<CCustomer> InsertCustomerAsync(CCustomer customer)
        {
            _storeDbContext.Add(customer);
            try
            {
                await _storeDbContext.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError($"Error in {nameof(InsertCustomerAsync)}: " + exp.Message);
            }

            return customer;

        }

        public async Task<bool> UpdateCustomerAsync(CCustomer customer)
        {
            _storeDbContext.Customers.Attach(customer);
            try
            {
                return (await _storeDbContext.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
                _loggerFactory.LogError($"Error in {nameof(UpdateCustomerAsync)}: " + exp.Message);
            }
            return false;

        }
    }
}

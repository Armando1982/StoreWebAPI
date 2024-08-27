using Microsoft.Extensions.Logging;
using Store.DataAccess.Data;
using Store.Models.Models;
using Store.Models.Models.DTO;

namespace Store.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _storeDbContext;
        private readonly ILogger _loggerFactory;
        public UserRepository(StoreDbContext storeDbContext, ILoggerFactory loggerFactory)
        {
            _storeDbContext = storeDbContext;
            _loggerFactory = loggerFactory.CreateLogger("UserRepository");

        }
        public Task<LoginDTO> LoginAsync(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> RegisterAsync(UserDTO user)
        {
            _storeDbContext.Add(user);
            try
            {
                await _storeDbContext.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
                _loggerFactory.LogError($"Error in {nameof(RegisterAsync)}: " + exp.Message);
            }

            return user;

        }
    }
}

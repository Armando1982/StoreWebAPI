using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.DataAccess.Data;
using Store.Models.Models;
using Store.Models.Models.DTO;
using StoreWebAPI.Infrastructure;

namespace StoreWebAPI.APIs
{
    [Route("api/User")]
    [AllowAnonymous]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly StoreDbContext _storeDbContext;
        private readonly SupportUser _supportUser;

        public UserController(StoreDbContext storeDbContext, SupportUser supportUser)
        {
            _storeDbContext = storeDbContext;
            _supportUser = supportUser;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserDTO user)
        {

            var modeloUsuario = new CUser
            {
                UserName = user.UserName,
                UserEmail = user.Email,
                Password = _supportUser.EncryptForPassword(user.Password)
            };

            await _storeDbContext.Users.AddAsync(modeloUsuario);
            await _storeDbContext.SaveChangesAsync();

            if (modeloUsuario.UserId != 0)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            var userSearched = await _storeDbContext.Users
                                                    .Where(u =>
                                                        u.UserEmail == login.Email &&
                                                        u.Password == _supportUser.EncryptForPassword(login.Password)
                                                      ).FirstOrDefaultAsync();

            if (userSearched == null)
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            else
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _supportUser.CreateJwt(userSearched) });
        }
        [HttpGet]
        [Route("TokenValidate")]
        public IActionResult TokenValidate([FromQuery] string token)
        {
            bool resp = _supportUser.ValidateToken(token);
            return StatusCode(StatusCodes.Status200OK, new { isSuccess = resp });
        }
    }
}

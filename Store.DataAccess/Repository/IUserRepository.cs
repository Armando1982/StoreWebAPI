using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Models.Models.DTO;

namespace Store.DataAccess.Repository
{
    public interface IUserRepository
    {
        Task<UserDTO>RegisterAsync(UserDTO userDTO);
        Task<LoginDTO>LoginAsync(LoginDTO loginDTO);
    }
}

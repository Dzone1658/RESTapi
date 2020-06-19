using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestWebApplication.Data.Models;

namespace TestWebApplication.Core.Interface
{
    public interface IUserService
    {
        Task<User> AddUserDetails(User user);
        Task<List<User>> GetUsers();
    }
}

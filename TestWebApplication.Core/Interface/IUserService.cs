using System.Collections.Generic;
using TestWebApplication.Data.Models;

namespace TestWebApplication.Domain.Interface
{
    public interface IUserService
    {
        User AddUserDetails(User user);
        List<User> GetUsers();
    }
}

using System.Collections.Generic;
using TestWebApplication.Data.Models;

namespace TestWebApplication.Core.Interface
{
    public interface IUserService
    {
        User AddUserDetails(User user);
        List<User> GetUsers();
    }
}

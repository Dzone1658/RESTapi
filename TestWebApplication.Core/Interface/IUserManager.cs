using System.Collections.Generic;
using TestWebApplication.Data.Models;

namespace TestWebApplication.Domain.Interface
{
    public interface IUserManager
    {
        User AddUserDetails(User user);
        List<User> GetUsers();
    }
}

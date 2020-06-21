using System;
using System.Collections.Generic;
using System.Text;
using TestWebApplication.Data.Models;

namespace TestWebApplication.Application.Interface
{
    public interface IUserBll
    {
        List<User> GetUsers();
        User AddUser(User user);
    }
}

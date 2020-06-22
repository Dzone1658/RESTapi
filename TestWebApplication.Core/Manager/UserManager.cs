using System.Collections.Generic;
using System.Linq;
using TestWebApplication.Data.Context;
using TestWebApplication.Data.Models;
using TestWebApplication.Domain.Interface;

namespace TestWebApplication.Domain.Manager
{
    public class UserManager : IUserManager
    {

        private readonly AppDbContext _context;

        public UserManager(AppDbContext context)
        {
            _context = context;
        }

        public User AddUserDetails(User user)
        {
            if ( user != null )
            {
                _context.Users.Add( user );
                _context.SaveChangesAsync( );
            }
            return user;
        }

        public List<User> GetUsers()
        {
            var userList = _context.Users.ToList( );
            return userList;
        }

    }
}

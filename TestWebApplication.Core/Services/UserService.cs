using System.Collections.Generic;
using System.Linq;
using TestWebApplication.Data.Context;
using TestWebApplication.Data.Models;
using TestWebApplication.Domain.Interface;

namespace TestWebApplication.Domain.Services
{
    public class UserService : IUserService
    {

        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
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

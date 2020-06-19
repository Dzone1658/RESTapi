using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestWebApplication.Core.Interface;
using TestWebApplication.Data.Context;
using TestWebApplication.Data.Models;

namespace TestWebApplication.Core.Services
{
    public class UserService : IUserService
    {

        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserDetails(User user)
        {
            if ( user != null )
            {
                _context.Users.Add( user );
                await _context.SaveChangesAsync( );
            }
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            //var result = ( from u in _context.Users
            //               select new User
            //               {
            //                   FullName = _context.Users.Reverse( ).FirstOrDefault( ).FullName,
            //                   Email = _context.Users.Reverse().FirstOrDefault().Email,
            //                   Notes = _context.Users.Reverse().FirstOrDefault().Notes
            //               } ).ToListAsync( );
            var result = _context.Users.ToListAsync( );
            return await result;
        }

        public static string ReverseCharacters(User user)
        {
            char[ ] array = user.FullName.ToCharArray( );
            Array.Reverse( array );
            return new string( array );
        }
    }
}

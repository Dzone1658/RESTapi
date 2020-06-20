using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = _context.Users.ToList( );
            List<User> userList = new List<User>( );
            foreach ( User item in result )
            {
                userList.Add( NewUser( item ) );
            }
            //var result = ( from U in _context.Users.ToList()
            //               select new User
            //               {
            //                   FullName = U.FullName.Reverse().
            //                   //Email = _context.Users.Reverse( ).FirstOrDefault( ).Email,
            //                   //Notes = _context.Users.Reverse( ).FirstOrDefault( ).Notes
            //               } ).ToList( );
            //return Enumerable.Reverse( result ).ToList( );
            return userList;
        }

        private string ReverseCharacters(string str)
        {
            char[ ] array = str.ToCharArray( );
            Array.Reverse( array );
            return new string( array );
        }

        private User NewUser(User user)
        {
            User model = new User( );
            model.UserId = user.UserId;
            model.FullName = ReverseCharacters( user.FullName );
            model.Email = ReverseCharacters( user.Email );
            model.Notes = ReverseCharacters( user.Notes );

            return model;
        }
    }
}

using System.Collections.Generic;
using TestWebApplication.Application.Interface;
using TestWebApplication.Application.Utility;
using TestWebApplication.Data.Models;
using TestWebApplication.Domain.Interface;

namespace TestWebApplication.Application.Bll
{
    public class UserBll : IUserBll
    {
        private readonly IUserManager _userService;


        public UserBll(IUserManager userService)
        {
            _userService = userService;
        }

        public List<User> GetUsers()
        {
            var result = _userService.GetUsers( );
            List<User> userList = new List<User>( );
            foreach ( User item in result )
            {
                userList.Add( NewUser( item ) );
            }
            return userList;
        }

        private User NewUser(User user)
        {
            User model = new User( );
            model.UserId = user.UserId;
            model.MobileNumber = user.MobileNumber;
            model.FullName = ReverseString.ReverseCharacters( user.FullName );
            model.Email = ReverseString.ReverseCharacters( user.Email );
            model.Notes = ReverseString.ReverseCharacters( user.Notes );

            return model;
        }

        public User AddUser(User user)
        {
            var result = _userService.AddUserDetails( user );
            return result;
        }
    }
}

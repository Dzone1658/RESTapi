using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestWebApplication.Core.Interface;
using TestWebApplication.Data.Models;

namespace TestWebApplication.API.Controllers
{
    [Route( "api/user" )]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            if ( ModelState.IsValid )
            {
                var result = _userService.GetUsers( );
                return Ok( result );
            }
            return NotFound( );
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<User> AddUser([FromBody] User user)
        {
            if ( ModelState.IsValid )
            {
                if ( user.FullName != null && user.Email != null )
                {
                    var result = _userService.AddUserDetails( user );
                    return Ok( result );
                }
                throw new Exception( "Invalid input" );
            }
            return NotFound( );
        }

    }
}

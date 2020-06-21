using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestWebApplication.Application.Interface;
using TestWebApplication.Data.Models;

namespace TestWebApplication.API.Controllers
{
    [Route( "api/user" )]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserBll _userBll;

        public UserController(IUserBll userBll)
        {
            _userBll = userBll;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            if ( ModelState.IsValid )
            {
                var users = _userBll.GetUsers( );
                return Ok( users );
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
                    var result = _userBll.AddUser( user );
                    return Ok( result );
                }
                throw new Exception( "Invalid input" );
            }
            return NotFound( );
        }

    }
}

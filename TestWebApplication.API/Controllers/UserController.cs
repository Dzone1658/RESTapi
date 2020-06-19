using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWebApplication.Core.Interface;
using TestWebApplication.Data.Models;

namespace TestWebApplication.API.Controllers
{
    [Route( "api/[controller]" )]
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
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if ( ModelState.IsValid )
            {
                var result = await _userService.GetUsers( );
                return Ok( result );
            }
            return BadRequest( );
        }

        // GET: api/User/5
        [HttpGet( "{id}", Name = "Get" )]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            if ( ModelState.IsValid )
            {
                if ( user.FullName != null && user.Email != null )
                {
                    var result = await _userService.AddUserDetails( user );
                    return Ok( result );
                }
            }
            return BadRequest( );
        }

    }
}

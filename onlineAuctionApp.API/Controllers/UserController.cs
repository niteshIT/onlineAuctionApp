using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onlineAuctionApp.BLL.IServices;
using OnlineAuctionApp.Dtos.Dtos;
using OnlineAuctionApp.Dtos.Dtos.onlineAuctionApp.BLL.Dtos;
using System.Data;

namespace onlineAuctionApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var token = _userService.Authenticate(userLoginDto);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { Token = token });
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin, user")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var updatedUser = _userService.UpdateUser(id, userUpdateDto);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

    }
}

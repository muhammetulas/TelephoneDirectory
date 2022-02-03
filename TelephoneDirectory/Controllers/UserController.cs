using Microsoft.AspNetCore.Mvc;
using TelephoneDirectory.Data.Entities;
using TelephoneDirectory.Data.Entities.ApiRequest;
using TelephoneDirectory.Services.Interfaces;

namespace TelephoneDirectory.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public IActionResult CreateUser(CreateUserRequest createUserRequest)
        {
            _userService.Create(createUserRequest);
            return Ok("Success");
        }

        [HttpDelete("delete")]
        public IActionResult DeleteUser(int userId)
        {
            return Ok(_userService.GetUsers());
        }

        [HttpPost("add-information")]
        public IActionResult AddInformationToUser(int userId)
        {
            return Ok(_userService.GetUsers());
        }

        [HttpDelete("delete-information")]
        public IActionResult DeleteInformationToUser(int userId, int informationId)
        {
            return Ok(_userService.GetUsers());
        }

        [HttpGet("list")]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpGet("get-user-and-detail")]
        public IActionResult GetUserAndDetail(int userId)
        {
            return Ok(_userService.GetUserById(userId));
        }
    }
}

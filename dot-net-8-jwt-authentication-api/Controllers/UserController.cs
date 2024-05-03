using dot_net_8_jwt_authentication_api.Helper;
using dot_net_8_jwt_authentication_api.Models;
using dot_net_8_jwt_authentication_api.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dot_net_8_jwt_authentication_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;



        /// <summary>
        /// This method is responsible for authenticating the user.
        /// It takes an instance of AuthenticateRequest as a parameter which contains the user's credentials.
        /// It uses the _userService to authenticate the user.
        /// If the authentication is successful, it returns an OkResult with the user's details.
        /// </summary>
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response =await _userService.Authenticate(model);
            return Ok(response);
        }


        /// <summary>
        /// This method is responsible for retrieving all users.
        /// It uses the _userService to get all users.
        /// If the operation is successful, it returns an OkResult with the list of users.
        /// </summary>
        
        // The Authorize attribute ensures that the user is authenticated before they can access this method.
        [CustomAuthorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Call the GetAll method of the _userService to retrieve all users.
            var users =await _userService.GetAll();

            // Return an OkResult with the list of users.
            return Ok(users);
        }


        // <summary>
        // Gets a user by their ID.
        // </summary>
        // <param name="id">The ID of the user to retrieve.</param>
        // <returns>An IActionResult that represents the result of the operation.</returns>
        [CustomAuthorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            // Call the GetAll method of the _userService to retrieve all users.
            var users = await _userService.GetAll();

            // Find user by id
            var userData = users.FirstOrDefault(x => x.Id == id);

            // Return an OkResult with the list of users.
            return Ok(userData);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) => _userService = userService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            var user = await _userService.RegisterAsync(req.Username, req.Password);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var token = await _userService.AuthenticateAsync(req.Username, req.Password);
            if (token == null) return Unauthorized("Invalid credentials");
            return Ok(new { token });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers() => Ok(await _userService.GetAllAsync());
    }

    public record RegisterRequest(string Username, string Password);
    public record LoginRequest(string Username, string Password);
}

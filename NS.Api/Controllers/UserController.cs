using System;
using NS.DTO.Acount;
using NS.Api.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace NS.Api.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticableUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IAuthenticableUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }


        [HttpGet("ChangePassword")]
        public async Task<IActionResult> ChangePassword()
        {
            throw new NotImplementedException();
        }

        [HttpGet("BlockDepartment")]
        public async Task<IActionResult> BlockDepartment()
        {
            throw new NotImplementedException();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserModel model)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UserModel model)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
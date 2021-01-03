using System;
using AutoMapper;
using System.Text;
using NS.DTO.Acount;
using NS.Api.Helpers;
using NS.Core.Services;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace NS.Api.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IOptions<AppSettings> appSettings, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService; 
            _appSettings = appSettings.Value;
            _mapper = mapper;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            var userModel = _mapper.Map<Core.Entities.User, UserModel>(user);

            var response = new AuthenticateResponse(userModel, token);

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

        [Helpers.Authorize]
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

        // helper methods
        private string generateJwtToken(Core.Entities.User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
﻿using System;
using AutoMapper;
using System.Text;
using NS.DTO.Acount;
using NS.Api.Helpers;
using NS.Core.Services;
using NS.Core.Entities;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace NS.Api.Controllers
{
    [Route("api/User")]
    public class UserController : NSControllerBase
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

        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return Unauthorized(new { message = "Username or password is incorrect" });

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            var userModel = _mapper.Map<User, UserModel>(user);

            var response = new AuthenticateResponse(userModel, token);

            return Ok(response);
        }

        [HttpGet]
        [NSAuthorize(NSRole.Management)]
        public async Task<IActionResult> Get()
        {
            var data = await _userService.GetAll();
            var dataModel = _mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(data);

            return Ok(dataModel);
        }

        [HttpGet("{id}")]
        [NSAuthorize(NSRole.Management)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
                return NotFound();

            var userModel = _mapper.Map<User, UserModel>(user);

            return Ok(userModel);
        }

        [HttpPost]
        [NSAuthorize(NSRole.Management)]
        public async Task<IActionResult> Create([FromBody] RequestUserModel model)
        {
            var userToCreate = _mapper.Map<RequestUserModel, User>(model);

            var newUser = await _userService.Create(userToCreate, model.Password);

            var newUserModel = _mapper.Map<User, UserModel>(newUser);

            return Created("", newUserModel);
        }

        [HttpPut("{id}")]
        [NSAuthorize(NSRole.Management)]
        public async Task<IActionResult> Update(int id, [FromBody] RequestUserModel model)
        {
            var userToCreate = _mapper.Map<RequestUserModel, User>(model);

            userToCreate.Id = id;
            var newUser = await _userService.Update(userToCreate, model.Password);

            //ToDo: If the account’s department is changed then other managers must be notified.

            var newUserModel = _mapper.Map<User, UserModel>(newUser);

            return Ok(newUserModel);
        }

        [HttpDelete("{id}")]
        [NSAuthorize(NSRole.Management)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
                return BadRequest();

            await _userService.Delete(id);

            return NoContent();
        }

        // helper methods
        private string generateJwtToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Department.Name)
            };

            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
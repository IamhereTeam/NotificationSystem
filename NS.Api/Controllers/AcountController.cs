using System;
using AutoMapper;
using NS.DTO.Acount;
using NS.Api.Helpers;
using NS.Core.Services;
using NS.Core.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace NS.Api.Controllers
{
    [Route("api/Acount")]
    public class AcountController : NSControllerBase
    {
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public AcountController(IUserService userService, IOptions<AppSettings> appSettings, IMapper mapper, ILogger<UserController> logger)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            var user = new User { Id = SesionUser.Id };
            var newUser = await _userService.Update(user, model.NewPassword);

            var newUserModel = _mapper.Map<User, UserModel>(newUser);

            return Ok(newUserModel);
        }

        [HttpPost("ApplySettings")]
        public async Task<IActionResult> ApplySettings([FromBody] UserSettingsModel model)
        {
            var entity = _mapper.Map<UserSettingsModel, UserSettings>(model);
            entity.Id = SesionUser.Id;

            var updatedEntity = await _userService.ApplySettings(entity);

            return Ok(updatedEntity);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _userService.GetById(SesionUser.Id);
            if (user == null)
                return NotFound();

            var userModel = _mapper.Map<User, UserModel>(user);

            return Ok(userModel);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RequestUserModel model)
        {
            // user is not allowed to update department for himself
            model.DepartmentId = 0;

            var userToCreate = _mapper.Map<RequestUserModel, User>(model);

            userToCreate.Id = SesionUser.Id;
            var newUser = await _userService.Update(userToCreate, model.Password);

            var newUserModel = _mapper.Map<User, UserModel>(newUser);

            return Ok(newUserModel);
        }
    }
}
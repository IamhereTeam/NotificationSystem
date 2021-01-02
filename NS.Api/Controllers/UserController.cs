using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NS.DTO.Acount;
using System;
using System.Threading.Tasks;

namespace NS.Api.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

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
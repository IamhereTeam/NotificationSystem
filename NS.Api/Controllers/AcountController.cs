using System;
using NS.DTO.Acount;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace NS.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class AcountController : ControllerBase
    {
        private readonly ILogger<AcountController> _logger;

        public AcountController(ILogger<AcountController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromForm] UserLoginModel model)
        {
            throw new NotImplementedException();
        }

        [HttpGet("Acount/ChangePassword")]
        public async Task<IActionResult> ChangePassword()
        {
            throw new NotImplementedException();
        }

        [HttpGet("Acount/BlockDepartment")]
        public async Task<IActionResult> BlockDepartment()
        {
            throw new NotImplementedException();
        }
    }
}

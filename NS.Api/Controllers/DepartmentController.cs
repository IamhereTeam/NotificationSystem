using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NS.DTO.Acount;
using System;
using System.Threading.Tasks;

namespace NS.Api.Controllers
{
    [ApiController]
    [Route("api/Department")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Post(DepartmentModel model)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DepartmentModel model)
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
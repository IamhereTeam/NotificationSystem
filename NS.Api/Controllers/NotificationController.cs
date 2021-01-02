using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace NS.Api.Controllers
{
    [ApiController]
    [Route("api/Notification")]
    public class NotificationController : ControllerBase
    {
        private readonly ILogger<NotificationController> _logger;

        public NotificationController(ILogger<NotificationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            throw new NotImplementedException();
        }
    }
}
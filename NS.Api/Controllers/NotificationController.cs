using AutoMapper;
using NS.Core.Entities;
using NS.Core.Services;
using NS.DTO.Notification;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NS.Api.Controllers
{
    [Route("api/Notification")]
    public class NotificationController : NSControllerBase
    {
        private readonly ILogger<NotificationController> _logger;
        private readonly INotificationService _notification;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notification, IMapper mapper, ILogger<NotificationController> logger)
        {
            _notification = notification;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateNotificationModel model)
        {
            var notification = _mapper.Map<NotificationModel, Notification>(model.Notification);

            await _notification.Create(SesionUser.Id, notification, model.Departments, model.Users);

            return Ok();
        }
    }
}
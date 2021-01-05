using AutoMapper;
using NS.Core.Entities;
using NS.Core.Services;
using NS.DTO.Notification;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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
            notification.UserId = SesionUser.Id;

            var createdNotification = await _notification.Create(notification);

            await _notification.Send(createdNotification, model.Departments, model.Users);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _notification.GetByUserId(SesionUser.Id);
            var dataModel = _mapper.Map<IEnumerable<UserNotification>, IEnumerable<UserNotificationModel>>(data);

            return Ok(dataModel);
        }

    }
}
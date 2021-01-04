using NS.Api.Helpers;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace NS.Api.Controllers
{
    [ApiController]
    [NSAuthorize]
    public class NSControllerBase : ControllerBase
    {
        public SesionUser SesionUser { get; }

        public NSControllerBase()
        {
            SesionUser = new SesionUser(this);
        }
    }

    public class SesionUser
    {
        private readonly ControllerBase _controllerBase;

        public SesionUser(ControllerBase controllerBase)
        {
            _controllerBase = controllerBase;
        }

        public int Id => int.Parse(_controllerBase.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        public string Username => _controllerBase.User.FindFirst(ClaimTypes.Name).Value;
        public string DepartmentName => _controllerBase.User.FindFirst(ClaimTypes.Role).Value;
    }
}
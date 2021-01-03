using Microsoft.AspNetCore.Mvc;
using NS.Api.Helpers;

namespace NS.Api.Controllers
{
    [ApiController]
    [NSAuthorize]
    public class NSControllerBase : ControllerBase
    {
        public NSControllerBase()
        {
        }
    }
}
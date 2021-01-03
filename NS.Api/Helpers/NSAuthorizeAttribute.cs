using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;

namespace NS.Api.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class NSAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _role;

        public NSAuthorizeAttribute()
        {
        }

        public NSAuthorizeAttribute(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool hasAllowAnonymous = context.ActionDescriptor.EndpointMetadata
                                .Any(em => em.GetType() == typeof(AllowAnonymousAttribute));

            if (hasAllowAnonymous) return;

            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                // not logged in
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!string.IsNullOrEmpty(_role) && !user.IsInRole(_role))
            {
                // forbidden
                context.Result = new JsonResult(new { title = "Forbidden", status = 403 }) { StatusCode = StatusCodes.Status403Forbidden };
            }
        }
    }
}
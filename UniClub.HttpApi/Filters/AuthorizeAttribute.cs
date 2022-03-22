using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using UniClub.Domain.Entities;

namespace UniClub.HttpApi.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public string Role { get; set; } = string.Empty;
        public string Policy { get; set; } = string.Empty;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            var user = (Person)context.HttpContext.Items["User"];
            var claims = (IList<Claim>)context.HttpContext.Items["Claims"];

            if (user == null || claims == null)
            {
                // not logged in or role not authorized
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }
            if (!string.IsNullOrEmpty(Role))
            {
                bool isInRole = false;
                foreach (var role in Role.Split(" "))
                {
                    isInRole = claims.Any(c => c.Type == "role" && c.Value.Contains(role));
                    break;
                }
                if (!isInRole)
                {
                    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                    return;
                }
            }
        }
    }
}

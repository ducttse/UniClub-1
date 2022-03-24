using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using UniClub.Domain.Common.Enums;
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
                    if (isInRole)
                    {
                        break;
                    }
                }
                if (!isInRole)
                {
                    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                    return;
                }
            }
            if (!string.IsNullOrEmpty(Policy))
            {
                bool isValid = false;
                switch (Policy)
                {
                    case ("ClubManager"):
                        isValid = claims.Any(c => c.Type == "club" && (c.Value.Contains(ClubRole.President.ToString()) || c.Value.Contains(ClubRole.Leader.ToString())));
                        break;
                    case ("InClub"):
                        isValid = claims.Any(c => c.Type == "club" && Enum.IsDefined(typeof(ClubRole), c.Value.Split("-")[1]));
                        break;
                    default:
                        return;
                }
                if (!isValid)
                {
                    context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                    return;
                }
            }
        }
    }
}

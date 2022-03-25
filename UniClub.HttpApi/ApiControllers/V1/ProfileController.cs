using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System;
using UniClub.Dtos.GetById;
using UniClub.HttpApi.Filters;
using UniClub.HttpApi.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;

namespace UniClub.HttpApi.ApiControllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                var claim = ((IList<Claim>)HttpContext.Items["Claims"]).FirstOrDefault(c => c.Type.Equals("user_id"));

                if (claim == null)
                {
                    return Unauthorized();
                }

                string id = claim.Value;

                var query = new GetUserByIdDto(id);
                var result = await Mediator.Send(query);
                return result != null ? Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK })
                    : NotFound(new ResponseResult() { Data = "User {id} is not found", StatusCode = HttpStatusCode.NotFound });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }
    }
}

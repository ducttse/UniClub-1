using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using UniClub.Application.Interfaces;
using UniClub.Dtos.Create;
using UniClub.Dtos.Delete;
using UniClub.Dtos.GetById;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Recover;
using UniClub.Dtos.Update;
using UniClub.HttpApi.Filters;
using UniClub.HttpApi.Models;

namespace UniClub.HttpApi.ApiControllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class ClubsController : ApiControllerBase
    {
        private readonly IFireBaseRegisterService _fireBaseRegisterService;

        public ClubsController(IFireBaseRegisterService fireBaseRegisterService)
        {
            _fireBaseRegisterService = fireBaseRegisterService;
        }

        [Authorize(Role = "SchoolAdmin Student")]
        [HttpGet]
        public async Task<IActionResult> GetClubsWithPagination([FromQuery] GetClubsWithPaginationDto query)
        {
            try
            {
                var claim = ((IList<Claim>)HttpContext.Items["Claims"]).FirstOrDefault(c => c.Type.Equals("university"));

                if (claim == null)
                {
                    return Unauthorized();
                }

                int uniId = int.Parse(claim.Value);
                query.SetUniId(uniId);
                var result = await Mediator.Send(query);
                return Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [Authorize(Role = "SchoolAdmin Student")]
        [HttpGet("{id}", Name = "GetClub")]
        public async Task<IActionResult> GetClub(int id)
        {
            try
            {
                var claim = ((IList<Claim>)HttpContext.Items["Claims"]).FirstOrDefault(c => c.Type.Equals("university"));

                if (claim == null)
                {
                    return Unauthorized();
                }

                int uniId = int.Parse(claim.Value);
                var query = new GetClubByIdDto(id, uniId);

                var result = await Mediator.Send(query);
                return result != null ? Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK })
                    : NotFound(new ResponseResult() { Data = $"Club {id} is not found", StatusCode = HttpStatusCode.NotFound });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [Authorize(Role = "SchoolAdmin")]
        [HttpPost]
        public async Task<IActionResult> CreateClub([FromForm] CreateClubDto command)
        {
            try
            {
                var claim = ((IList<Claim>)HttpContext.Items["Claims"]).FirstOrDefault(c => c.Type.Equals("university"));

                if (claim == null)
                {
                    return Unauthorized();
                }

                command.SetUniId(int.Parse(claim.Value));

                var result = await Mediator.Send(command);
                return CreatedAtRoute(nameof(GetClub), new { id = result }, command);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [Authorize(Role = "SchoolAdmin")]

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClub(int id, [FromForm] UpdateClubDto command)
        {
            try
            {
                var claim = ((IList<Claim>)HttpContext.Items["Claims"]).FirstOrDefault(c => c.Type.Equals("university"));

                if (claim == null)
                {
                    return Unauthorized();
                }

                int uniId = int.Parse(claim.Value);
                command.SetUniId(uniId);
                if (command.Id.Equals(id))
                {
                    var result = await Mediator.Send(command);
                    return NoContent();
                }
                else
                {
                    return BadRequest(new ResponseResult() { StatusCode = HttpStatusCode.BadRequest, Data = "Invalid object" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [Authorize(Role = "SchoolAdmin")]
        [HttpPut("{id}/recover")]
        public async Task<IActionResult> RecoverClub(int id, [FromBody] RecoverClubDto command)
        {
            try
            {
                if (command.Id.Equals(id))
                {
                    var claim = ((IList<Claim>)HttpContext.Items["Claims"]).FirstOrDefault(c => c.Type.Equals("university"));

                    if (claim == null)
                    {
                        return Unauthorized();
                    }

                    command.SetUniId(int.Parse(claim.Value));

                    var result = await Mediator.Send(command);
                    return NoContent();
                }
                else
                {
                    return BadRequest(new ResponseResult() { StatusCode = HttpStatusCode.BadRequest, Data = "Invalid object" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [Authorize(Role = "SchoolAdmin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            try
            {
                var claim = ((IList<Claim>)HttpContext.Items["Claims"]).FirstOrDefault(c => c.Type.Equals("university"));

                if (claim == null)
                {
                    return Unauthorized();
                }

                int uniId = int.Parse(claim.Value);

                var command = new DeleteClubDto(id, uniId);
                var result = await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [Authorize(Role = "SchoolAdmin")]
        [HttpPost("{id}/club-admin")]
        public async Task<IActionResult> CreateClubAdmin(int id, [FromForm] CreateClubAdminDto command)
        {
            try
            {
                var claim = ((IList<Claim>)HttpContext.Items["Claims"]).FirstOrDefault(c => c.Type.Equals("university"));

                if (claim == null)
                {
                    return Unauthorized();
                }

                command.SetUniId(int.Parse(claim.Value));
                command.SetClubId(id);

                var result = await Mediator.Send(command);
                await _fireBaseRegisterService.RegisterToFireBase(command.Email, command.Password);
                return CreatedAtRoute(nameof(GetClub), new { id = result }, command);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }
    }
}

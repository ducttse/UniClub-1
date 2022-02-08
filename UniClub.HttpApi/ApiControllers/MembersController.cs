using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using UniClub.Application.Members.Commands.CreateMember;
using UniClub.Application.Members.Commands.DeleteMember;
using UniClub.Application.Members.Commands.UpdateMember;
using UniClub.Application.Members.Queries.GetMemberById;
using UniClub.Application.Members.Queries.GetMembersWithPagination;
using UniClub.HttpApi.Models;

namespace UniClub.HttpApi.ApiControllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MembersController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetMembersWithPagination([FromQuery] GetMembersWithPaginationQuery query)
        {
            try
            {
                var result = await Mediator.Send(query);
                return Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpGet("{id}", Name = "GetMember")]
        public async Task<IActionResult> GetMember(int id)
        {
            try
            {
                var query = new GetMemberByIdQuery(id);
                var result = await Mediator.Send(query);
                return result != null ? Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK })
                    : NotFound(new ResponseResult() { Data = $"Member {id} is not found", StatusCode = HttpStatusCode.NotFound });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember([FromBody] CreateMemberCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);
                return CreatedAtRoute(nameof(GetMember), new { id = result }, command);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, [FromBody] UpdateMemberCommand command)
        {
            try
            {
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            try
            {
                var command = new DeleteMemberCommand(id);
                var result = await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }
    }
}

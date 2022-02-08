using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using UniClub.Application.Clubs.Commands.CreateClub;
using UniClub.Application.Clubs.Commands.DeleteClub;
using UniClub.Application.Clubs.Commands.UpdateClub;
using UniClub.Application.Clubs.Queries.GetClubById;
using UniClub.Application.Clubs.Queries.GetClubsWithPagination;
using UniClub.HttpApi.Models;

namespace UniClub.HttpApi.ApiControllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClubsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetClubsWithPagination([FromQuery] GetClubsWithPaginationQuery query)
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

        [HttpGet("{id}", Name = "GetClub")]
        public async Task<IActionResult> GetClub(int id)
        {
            try
            {
                var query = new GetClubByIdQuery(id);
                var result = await Mediator.Send(query);
                return result != null ? Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK })
                    : NotFound(new ResponseResult() { Data = $"Club {id} is not found", StatusCode = HttpStatusCode.NotFound });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateClub([FromBody] CreateClubCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);
                return CreatedAtRoute(nameof(GetClub), new { id = result }, command);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClub(int id, [FromBody] UpdateClubCommand command)
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
        public async Task<IActionResult> DeleteClub(int id)
        {
            try
            {
                var command = new DeleteClubCommand(id);
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

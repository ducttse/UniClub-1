using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using UniClub.Application.ClubTasks.Commands.CreateClubTask;
using UniClub.Application.ClubTasks.Commands.DeleteClubTask;
using UniClub.Application.ClubTasks.Commands.UpdateClubTask;
using UniClub.Application.ClubTasks.Queries.GetClubTaskById;
using UniClub.Application.ClubTasks.Queries.GetClubTasksWithPagination;
using UniClub.HttpApi.Models;

namespace UniClub.HttpApi.ApiControllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClubTasksController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetClubTasksWithPagination([FromQuery] GetClubTasksWithPaginationQuery query)
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

        [HttpGet("{id}", Name = "GetClubTask")]
        public async Task<IActionResult> GetClubTask(int id)
        {
            try
            {
                var query = new GetClubTaskByIdQuery(id);
                var result = await Mediator.Send(query);
                return result != null ? Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK })
                    : NotFound(new ResponseResult() { Data = $"ClubTask {id} is not found", StatusCode = HttpStatusCode.NotFound });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateClubTask([FromBody] CreateClubTaskCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);
                return CreatedAtRoute(nameof(GetClubTask), new { id = result }, command);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClubTask(int id, [FromBody] UpdateClubTaskCommand command)
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
        public async Task<IActionResult> DeleteClubTask(int id)
        {
            try
            {
                var command = new DeleteClubTaskCommand(id);
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

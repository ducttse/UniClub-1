using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using UniClub.Application.Events.Commands.CreateEvent;
using UniClub.Application.Events.Commands.DeleteEvent;
using UniClub.Application.Events.Commands.UpdateEvent;
using UniClub.Application.Events.Queries.GetEventById;
using UniClub.Application.Events.Queries.GetEventsWithPagination;
using UniClub.HttpApi.Models;

namespace UniClub.HttpApi.ApiControllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EventsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetEventsWithPagination([FromQuery] GetEventsWithPaginationQuery query)
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

        [HttpGet("{id}", Name = "GetEvent")]
        public async Task<IActionResult> GetEvent(int id)
        {
            try
            {
                var query = new GetEventByIdQuery(id);
                var result = await Mediator.Send(query);
                return result != null ? Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK })
                    : NotFound(new ResponseResult() { Data = $"Event {id} is not found", StatusCode = HttpStatusCode.NotFound });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);
                return CreatedAtRoute(nameof(GetEvent), new { id = result }, command);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] UpdateEventCommand command)
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
        public async Task<IActionResult> DeleteEvent(int id)
        {
            try
            {
                var command = new DeleteEventCommand(id);
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

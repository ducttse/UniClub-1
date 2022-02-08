using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using UniClub.Application.Universities.Commands.CreateUniversity;
using UniClub.Application.Universities.Commands.DeleteUniversity;
using UniClub.Application.Universities.Commands.UpdateUniversity;
using UniClub.Application.Universities.Queries.GetUniversitiesWithPagination;
using UniClub.Application.Universities.Queries.GetUniversityById;
using UniClub.HttpApi.ApiControllers;
using UniClub.HttpApi.Models;

[ApiController]
[Route("api/v1/[controller]")]
public class UniversitiesController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUniversitiesWithPagination([FromQuery] GetUniversitiesWithPaginationQuery query)
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

    [HttpGet("{id}", Name = "GetUniversity")]
    public async Task<IActionResult> GetUniversity(int id)
    {
        try
        {
            var query = new GetUniversityByIdQuery(id);
            var result = await Mediator.Send(query);
            return result != null ? Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK })
                : NotFound(new ResponseResult() { Data = $"University {id} is not found", StatusCode = HttpStatusCode.NotFound });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUniversity([FromBody] CreateUniversityCommand command)
    {
        try
        {
            var result = await Mediator.Send(command);
            return CreatedAtRoute(nameof(GetUniversity), new { id = result }, command);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUniversity(int id, [FromBody] UpdateUniversityCommand command)
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
    public async Task<IActionResult> DeleteUniversity(int id)
    {
        try
        {
            var command = new DeleteUniversityCommand(id);
            var result = await Mediator.Send(command);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
        }
    }
}

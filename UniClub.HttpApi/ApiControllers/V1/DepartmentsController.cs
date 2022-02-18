using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using UniClub.Application.Departments.Commands.CreateDepartment;
using UniClub.Application.Departments.Commands.DeleteDepartment;
using UniClub.Application.Departments.Commands.UpdateDepartment;
using UniClub.Application.Departments.Queries.GetDepartmentById;
using UniClub.Application.Departments.Queries.GetDepartmentsWithPagination;
using UniClub.HttpApi.Models;

namespace UniClub.HttpApi.ApiControllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DepartmentsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetDepartmentsWithPagination([FromQuery] GetDepartmentsWithPaginationQuery query)
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

        [HttpGet("{id}", Name = "GetDepartment")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            try
            {
                var query = new GetDepartmentByIdQuery(id);
                var result = await Mediator.Send(query);
                return result != null ? Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK })
                    : NotFound(new ResponseResult() { Data = $"Department {id} is not found", StatusCode = HttpStatusCode.NotFound });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);
                return CreatedAtRoute(nameof(GetDepartment), new { id = result }, command);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] UpdateDepartmentCommand command)
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
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                var command = new DeleteDepartmentCommand(id);
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

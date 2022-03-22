using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
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
    [Authorize(Role = "SchoolAdmin")]
    public class DepartmentsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetDepartmentsWithPagination([FromQuery] GetDepartmentsWithPaginationDto query)
        {
            try
            {
                var claim = ((IList<Claim>)HttpContext.Items["Claims"]).FirstOrDefault(c => c.Type.Equals("university"));

                if (claim == null)
                {
                    return Unauthorized();
                }

                query.SetUniId(int.Parse(claim.Value));
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
                var claim = ((IList<Claim>)HttpContext.Items["Claims"]).FirstOrDefault(c => c.Type.Equals("university"));

                if (claim == null)
                {
                    return Unauthorized();
                }

                var uniId = int.Parse(claim.Value);

                var query = new GetDepartmentByIdDto(id, uniId);
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
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentDto command)
        {
            try
            {
                var claim = ((IList<Claim>)HttpContext.Items["Claims"]).FirstOrDefault(c => c.Type.Equals("university"));

                if (claim == null)
                {
                    return Unauthorized();
                }

                var uniId = int.Parse(claim.Value);
                command.SetUniId(uniId);

                var result = await Mediator.Send(command);
                return CreatedAtRoute(nameof(GetDepartment), new { id = result }, command);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] UpdateDepartmentDto command)
        {
            try
            {
                var claim = ((IList<Claim>)HttpContext.Items["Claims"]).FirstOrDefault(c => c.Type.Equals("university"));

                if (claim == null)
                {
                    return Unauthorized();
                }
                var uniId = int.Parse(claim.Value);

                if (command.Id.Equals(id))
                {
                    command.SetUniId(uniId);

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

        [HttpPut("{id}/recover")]
        public async Task<IActionResult> RecoverDepartment(int id, [FromBody] RecoverDepartmentDto command)
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
                var command = new DeleteDepartmentDto(id);
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

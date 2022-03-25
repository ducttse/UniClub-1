using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using UniClub.Application.Interfaces;
using UniClub.Domain.Common.Enums;
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
    public class StudentsController : ApiControllerBase
    {
        private IFireBaseRegisterService _fireBaseRegisterService;

        public StudentsController(IFireBaseRegisterService fireBaseRegisterService)
        {
            _fireBaseRegisterService = fireBaseRegisterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentsWithPagination([FromQuery] GetStudentsWithPaginationDto query)
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

        [HttpGet("{id}", Name = "GetStudent")]
        public async Task<IActionResult> GetStudent(string id)
        {
            try
            {
                var claim = ((IList<Claim>)HttpContext.Items["Claims"]).FirstOrDefault(c => c.Type.Equals("university"));

                if (claim == null)
                {
                    return Unauthorized();
                }

                int uniId = int.Parse(claim.Value);

                var query = new GetStudentByIdDto(id, uniId);
                var result = await Mediator.Send(query);

                return result != null ? Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK })
                    : NotFound(new ResponseResult() { Data = $"Student {id} is not found", StatusCode = HttpStatusCode.NotFound });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromForm] CreateUserDto command)
        {
            try
            {
                if (command.DepId == null)
                {
                    throw new Exception("DepId cannot be empty");
                }
                command.Role = Role.Student;
                var result = await Mediator.Send(command);
                await _fireBaseRegisterService.RegisterToFireBase(command.Email, command.Password);
                return CreatedAtRoute(nameof(GetStudent), new { id = result }, command);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(string id, [FromForm] UpdateUserDto command)
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
        public async Task<IActionResult> DeleteStudent(string id)
        {
            try
            {
                var command = new DeleteUserDto(id);
                var result = await Mediator.Send(command);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPut("{id}/recover")]
        public async Task<IActionResult> RecoverStudent(string id, [FromBody] RecoverUserDto command)
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
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using UniClub.Domain.Common.Enums;
using UniClub.Dtos.Delete;
using UniClub.Dtos.GetById;
using UniClub.Dtos.GetWithPagination;
using UniClub.Dtos.Update;
using UniClub.HttpApi.Models;

namespace UniClub.HttpApi.ApiControllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsersWithPagination([FromQuery] GetUsersWithPaginationDto query)
        {
            try
            {
                query.SetRole(Role.Anonymous);
                var result = await Mediator.Send(query);
                return Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(string id)
        {
            try
            {
                var query = new GetUserByIdDto(id, Role.Anonymous);
                var result = await Mediator.Send(query);
                return result != null ? Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK })
                    : NotFound(new ResponseResult() { Data = $"User {id} is not found", StatusCode = HttpStatusCode.NotFound });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateUser([FromBody] CreateUserDto command)
        //{
        //    try
        //    {
        //        command.SetRole(Role.Anonymous);
        //        var result = await Mediator.Send(command);
        //        return CreatedAtRoute(nameof(GetUser), new { id = result }, command);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
        //    }
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto command)
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
        public async Task<IActionResult> DeleteUser(string id)
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
    }
}

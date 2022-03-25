using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using UniClub.Dtos.GetById;
using UniClub.Dtos.GetWithPagination;
using UniClub.HttpApi.Filters;
using UniClub.HttpApi.Models;

namespace UniClub.HttpApi.ApiControllers.V1
{
    [ApiController]
    [Route("api/v1/posts/{pid}/[controller]")]
    [Authorize]
    public class PostImagesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPostImagesWithPagination(int pid)
        {
            try
            {
                if (pid < 0)
                {
                    return BadRequest();
                }
                var query = new GetPostImagesDto(pid);
                var result = await Mediator.Send(query);
                return Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpGet("{id}", Name = "GetPostImage")]
        public async Task<IActionResult> GetPostImage(int pid, int id)
        {
            try
            {
                if (pid < 0)
                {
                    return BadRequest();
                }
                var query = new GetPostImageByIdDto(pid, id);
                var result = await Mediator.Send(query);
                return result != null ? Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK })
                    : NotFound(new ResponseResult() { Data = $"PostImage {id} is not found", StatusCode = HttpStatusCode.NotFound });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> CreatePostImage([FromBody] CreatePostImageDto command)
        //{
        //    try
        //    {
        //        var result = await Mediator.Send(command);
        //        return CreatedAtRoute(nameof(GetPostImage), new { id = result }, command);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
        //    }
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdatePostImage(int id, [FromBody] UpdatePostImageDto command)
        //{
        //    try
        //    {
        //        if (command.Id.Equals(id))
        //        {
        //            var result = await Mediator.Send(command);
        //            return NoContent();
        //        }
        //        else
        //        {
        //            return BadRequest(new ResponseResult() { StatusCode = HttpStatusCode.BadRequest, Data = "Invalid object" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
        //    }
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePostImage(int id)
        //{
        //    try
        //    {
        //        var command = new DeletePostImageDto(id);
        //        var result = await Mediator.Send(command);
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
        //    }
        //}
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using UniClub.Application.PostImages.Commands.CreatePostImage;
using UniClub.Application.PostImages.Commands.DeletePostImage;
using UniClub.Application.PostImages.Commands.UpdatePostImage;
using UniClub.Application.PostImages.Queries.GetPostImagesWithPagination;
using UniClub.Application.PostImages.Queries.GetPostImageWithId;
using UniClub.HttpApi.Models;

namespace UniClub.HttpApi.ApiControllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PostImagesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPostImagesWithPagination()
        {
            try
            {
                var query = new GetPostImagesQuery();
                var result = await Mediator.Send(query);
                return Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpGet("{id}", Name = "GetPostImage")]
        public async Task<IActionResult> GetPostImage(int id)
        {
            try
            {
                var query = new GetPostImageByIdQuery(id);
                var result = await Mediator.Send(query);
                return result != null ? Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK })
                    : NotFound(new ResponseResult() { Data = $"PostImage {id} is not found", StatusCode = HttpStatusCode.NotFound });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostImage([FromBody] CreatePostImageCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);
                return CreatedAtRoute(nameof(GetPostImage), new { id = result }, command);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePostImage(int id, [FromBody] UpdatePostImageCommand command)
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
        public async Task<IActionResult> DeletePostImage(int id)
        {
            try
            {
                var command = new DeletePostImageCommand(id);
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

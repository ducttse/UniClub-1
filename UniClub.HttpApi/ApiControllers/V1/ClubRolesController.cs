﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using UniClub.Application.ClubRoles.Commands.CreateClubRole;
using UniClub.Application.ClubRoles.Commands.DeleteClubRole;
using UniClub.Application.ClubRoles.Commands.UpdateClubRole;
using UniClub.Application.ClubRoles.Queries.GetClubRoleById;
using UniClub.Application.ClubRoles.Queries.GetClubRolesWithPagination;
using UniClub.HttpApi.Models;

namespace UniClub.HttpApi.ApiControllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClubRolesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetClubRolesWithPagination([FromQuery] GetClubRolesWithPaginationQuery query)
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

        [HttpGet("{id}", Name = "GetClubRole")]
        public async Task<IActionResult> GetClubRole(int id)
        {
            try
            {
                var query = new GetClubRoleByIdQuery(id);
                var result = await Mediator.Send(query);
                return result != null ? Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK })
                    : NotFound(new ResponseResult() { Data = $"ClubRole {id} is not found", StatusCode = HttpStatusCode.NotFound });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateClubRole([FromBody] CreateClubRoleCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);
                return CreatedAtRoute(nameof(GetClubRole), new { id = result }, command);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClubRole(int id, [FromBody] UpdateClubRoleCommand command)
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
        public async Task<IActionResult> DeleteClubRole(int id)
        {
            try
            {
                var command = new DeleteClubRoleCommand(id);
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

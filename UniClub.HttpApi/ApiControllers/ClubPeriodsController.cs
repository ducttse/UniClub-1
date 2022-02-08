﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using UniClub.Application.ClubPeriods.Commands.CreateClubPeriod;
using UniClub.Application.ClubPeriods.Commands.DeleteClubPeriod;
using UniClub.Application.ClubPeriods.Commands.UpdateClubPeriod;
using UniClub.Application.ClubPeriods.Queries.GetClubPeriodsWithPagination;
using UniClub.Application.ClubPeriods.Queries.GetClubPeriodWithId;
using UniClub.HttpApi.Models;

namespace UniClub.HttpApi.ApiControllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClubPeriodsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetClubPeriodsWithPagination([FromQuery] GetClubPeriodsWithPaginationQuery query)
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

        [HttpGet("{id}", Name = "GetClubPeriod")]
        public async Task<IActionResult> GetClubPeriod(int id)
        {
            try
            {
                var query = new GetClubPeriodByIdQuery(id);
                var result = await Mediator.Send(query);
                return result != null ? Ok(new ResponseResult() { Data = result, StatusCode = HttpStatusCode.OK })
                    : NotFound(new ResponseResult() { Data = $"ClubPeriod {id} is not found", StatusCode = HttpStatusCode.NotFound });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateClubPeriod([FromBody] CreateClubPeriodCommand command)
        {
            try
            {
                var result = await Mediator.Send(command);
                return CreatedAtRoute(nameof(GetClubPeriod), new { id = result }, command);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseResult() { StatusCode = HttpStatusCode.InternalServerError, Data = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClubPeriod(int id, [FromBody] UpdateClubPeriodCommand command)
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
        public async Task<IActionResult> DeleteClubPeriod(int id)
        {
            try
            {
                var command = new DeleteClubPeriodCommand(id);
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

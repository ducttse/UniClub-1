using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniClub.Application.Universities.Commands;
using UniClub.Application.Universities.Dtos;
using UniClub.Application.Universities.Queries.GetUniversitiesWithPagination;
using UniClub.Application.Universities.Queries.GetUniversityWithId;
using UniClub.Domain.Common;

namespace UniClub.HttpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<UniversityDto>>> GetUniversitiesWithPagination([FromQuery] GetUniversitiesWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUniversity(int id)
        {
            var query = new GetUniversityByIdQuery(id);
            var result = await Mediator.Send(query);
            return result != null ? (IActionResult) Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUniversity([FromBody] CreateUniversityCommand command)
        {
            var result = await Mediator.Send(command);
            return CreatedAtAction("GetUniversity", new { Id = result });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUniversity([FromBody] CreateUniversityCommand command)
        {
            var result = await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUniversity(int id)
{
            var command = new DeleteUniversityCommand(id);
            var result = await Mediator.Send(command);
            return NoContent();
        }
    }
}

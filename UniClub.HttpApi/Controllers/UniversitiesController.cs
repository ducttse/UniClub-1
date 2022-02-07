using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniClub.Application.Universities.Queries.GetUniversityWithPagination;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;

namespace UniClub.HttpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversitiesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedList<University>>> Get()
        {
            return await Mediator.Send(new GetUniversitiesWithPaginationQuery());
        }
    }
}

using UniClub.Domain.Entities;
using UniClub.Dtos.GetById;
using UniClub.Specifications;

namespace UniClub.Queries.GetById.Specifications
{
    public class GetUserByIdQuerySpecification : BaseSpecification<Person>
    {
        public GetUserByIdQuerySpecification(GetUserByIdDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);
            SetFilterCondition(e => e.Id == dto.Id);
        }
    }
}

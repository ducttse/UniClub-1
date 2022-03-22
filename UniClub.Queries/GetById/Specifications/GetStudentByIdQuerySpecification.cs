using UniClub.Domain.Entities;
using UniClub.Dtos.GetById;
using UniClub.Specifications;

namespace UniClub.Queries.GetById.Specifications
{
    public class GetStudentByIdQuerySpecification : BaseSpecification<Person>
    {
        public GetStudentByIdQuerySpecification(GetStudentByIdDto dto)
        {
            SetFilterCondition(e => !e.IsDeleted);
            SetFilterCondition(e => e.Id == dto.Id && e.Dep.UniId == dto.UniId);
            AddInclude(e => e.Dep);
        }
    }
}

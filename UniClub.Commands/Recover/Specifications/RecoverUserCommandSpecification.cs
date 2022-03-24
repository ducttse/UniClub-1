using UniClub.Domain.Entities;
using UniClub.Dtos.Recover;
using UniClub.Specifications;

namespace UniClub.Commands.Recover.Specifications
{
    public class RecoverUserCommandSpecification : BaseSpecification<Person>
    {
        public RecoverUserCommandSpecification(RecoverUserDto dto)
        {
            SetFilterCondition(e => e.IsDeleted);

            SetFilterCondition(e => e.Id.Equals(dto.Id));
        }
    }
}

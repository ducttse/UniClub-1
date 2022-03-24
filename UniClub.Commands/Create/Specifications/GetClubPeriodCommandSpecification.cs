using UniClub.Domain.Entities;
using UniClub.Specifications;

namespace UniClub.Commands.Create.Specifications
{
    public class GetClubPeriodCommandSpecification : BaseSpecification<ClubPeriod>
    {
        public GetClubPeriodCommandSpecification(int id)
        {
            SetFilterCondition(e => !e.IsDeleted);

            SetFilterCondition(e => e.Id == id && e.IsPresent);
        }
    }
}

using System;

namespace UniClub.Domain.Shared.Interfaces
{
    public interface IHasCreationTime
    {
        DateTime CreationTime { get; set; }
    }
}

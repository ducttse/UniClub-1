using System;

namespace UniClub.Domain.Shared.Interfaces
{
    public interface IHasModificationTime
    {
        DateTime ModificationTime { get; set; }
    }
}

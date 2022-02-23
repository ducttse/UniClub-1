namespace UniClub.Domain.Shared.Interfaces
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
        bool IsHardDeleted { get; set; }
    }
}

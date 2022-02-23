namespace UniClub.Domain.Shared.Interfaces
{
    public interface IMayHaveCreator
    {
        string? CreatedBy { get; set; }
    }
}

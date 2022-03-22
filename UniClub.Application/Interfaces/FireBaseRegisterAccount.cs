using System.Threading.Tasks;

namespace UniClub.Application.Interfaces
{
    public interface IFireBaseRegisterService
    {
        Task RegisterToFireBase(string email, string password);
    }
}

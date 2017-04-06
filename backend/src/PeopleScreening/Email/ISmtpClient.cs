using System.Threading.Tasks;

namespace PeopleScreening.Email
{
    public interface ISmtpClient
    {
        Task SendAsync(string email, string message);
    }
}
using System.Threading.Tasks;

namespace PeopleScreening.Email
{
    public class DummySmtpClient : ISmtpClient
    {
        public Task SendAsync(string email, string message)
        {
            return Task.CompletedTask;
        }
    }
}
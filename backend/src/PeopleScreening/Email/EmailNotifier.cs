using System.Threading.Tasks;
using PeopleScreening.Model;
using PeopleScreening.Services;

namespace PeopleScreening.Email
{
    public class EmailNotifier : INotifier
    {
        private readonly ISmtpClient _client;

        public EmailNotifier(SmtpClientFactory smtpFactory)
        {
            _client = smtpFactory.CreateClient();
        }

        public Task NotifyAsync(Employee employee, string message)
        {
            return _client.SendAsync(employee.Alias, message);
        }
    }
}
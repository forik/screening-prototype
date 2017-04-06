using System.Threading.Tasks;
using PeopleScreening.Model;

namespace PeopleScreening.Services
{
    public interface INotifier
    {
        Task NotifyAsync(Employee employee, string message);
    }
}
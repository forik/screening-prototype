using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeopleScreening.Services;

namespace PeopleScreening.Controllers
{
    [Route("api/employee")]
    public class EmployeeNotificationController : Controller
    {
        [Route("notifications/expiredscreening")]
        [HttpPost]
        public async Task<IActionResult> NotifyEmployeesWithExpiredScreenings(
            [FromServices] ExpiredScreeningsNotifier notifier)
        {
            await notifier.NotifyEmployees().ConfigureAwait(false);
            return Ok();
        }
    }
}
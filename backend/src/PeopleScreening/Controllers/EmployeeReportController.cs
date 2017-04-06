using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PeopleScreening.Services;

namespace PeopleScreening.Controllers
{
    [Route("api/employee")]
    public class EmployeeReportController : Controller
    {
        [Route("report/screening/maxexpiration")]
        public async Task<IActionResult> GetScreeningDataWithMaxExpiration(
            [FromServices] IQuery<LastScreeningExpirationReportDto> query)
        {
            var data = await query.ExecuteAsync().ConfigureAwait(false);
            return Ok(data);
        }
    }
}
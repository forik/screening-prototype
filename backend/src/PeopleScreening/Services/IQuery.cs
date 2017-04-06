using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleScreening.Services
{
    public interface IQuery<TReportData>
    {
        Task<IEnumerable<TReportData>> ExecuteAsync();
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PeopleScreening.Data;
using PeopleScreening.Properties;
using PeopleScreening.Utils;

namespace PeopleScreening.Services
{
    public class LastScreeningExpirationQuery : IQuery<LastScreeningExpirationReportDto>
    {
        private readonly PeopleScreeningContext _context;

        public LastScreeningExpirationQuery(PeopleScreeningContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<LastScreeningExpirationReportDto>> ExecuteAsync()
        {
            var data = await _context.ExecuteEnumerableAsync<LastScreeningExpirationReportDto>(Resources.MaxScreeningReportQuery).ConfigureAwait(false);
            return data;
        }
    }

    public class LastScreeningExpirationReportDto
    {
        public string Employee { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string ScreeningName { get; set; }
        public string Manager { get; set; }
        public string SkipManager { get; set; }
        public string TeamName { get; set; }
    }

}
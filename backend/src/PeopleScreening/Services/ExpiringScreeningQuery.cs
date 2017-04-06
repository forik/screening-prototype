using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeopleScreening.Data;
using PeopleScreening.Model;

namespace PeopleScreening.Services
{
    public class ExpiringScreeningQuery : IQuery<ExpiringScreeningWrapper>
    {
        private readonly PeopleScreeningContext _context;

        public ExpiringScreeningQuery(PeopleScreeningContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExpiringScreeningWrapper>> ExecuteAsync()
        {
            var now = DateTime.UtcNow;
            var data = await _context.Set<EmployeeScreening>()
                .Include(x => x.Employee)
                .Include(x => x.Screening)
                .Where(x => x.ExpirationDate <= now)
                .Where(x => !x.NotificationIsInProgress || x.NotificationSentDate == null)
                .Select(x => new ExpiringScreeningWrapper{EmployeeScreening = x})
                .ToListAsync().ConfigureAwait(false);

            return data;
        }
    }

    public class ExpiringScreeningWrapper
    {
        public EmployeeScreening EmployeeScreening { get; set; }
    }
}
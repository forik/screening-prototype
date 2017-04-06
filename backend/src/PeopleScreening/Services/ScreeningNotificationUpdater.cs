using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleScreening.Data;
using PeopleScreening.Model;

namespace PeopleScreening.Services
{
    public class ScreeningNotificationUpdater
    {
        private readonly PeopleScreeningContext _context;

        public ScreeningNotificationUpdater(PeopleScreeningContext context)
        {
            _context = context;
        }

        public Task SetInProgressAsync(IEnumerable<EmployeeScreening> screenings)
        {
            foreach (var screening in screenings.AsParallel())
            {
                screening.NotificationIsInProgress = true;
            }

            return _context.SaveChangesAsync();
        }

        public Task SetNotifiedDateAsync(IEnumerable<EmployeeScreening> screenings, DateTime date)
        {
            foreach (var screening in screenings.AsParallel())
            {
                screening.NotificationSentDate = date;
            }

            return _context.SaveChangesAsync();
        }
    }
}
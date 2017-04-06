using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.Extensions.Logging;

namespace PeopleScreening.Services
{
    public class ExpiredScreeningsNotifier
    {
        // TODO add error handling

        private readonly IQuery<ExpiringScreeningWrapper> _query;
        private readonly INotifier _notifier;
        private readonly ScreeningNotificationUpdater _updater;
        private readonly ILogger<ExpiredScreeningsNotifier> _logger;
        private readonly ActionBlock<ExpiringScreeningWrapper> _emailSender;
        private readonly BatchBlock<ExpiringScreeningWrapper> _batchBlock;

        public ExpiredScreeningsNotifier(
            IQuery<ExpiringScreeningWrapper> query,
            INotifier notifier,
            ScreeningNotificationUpdater updater,
            ILogger<ExpiredScreeningsNotifier> logger)
        {
            _query = query;
            _notifier = notifier;
            _updater = updater;
            _logger = logger;

            _batchBlock = new BatchBlock<ExpiringScreeningWrapper>(100);
            var notifiationSentAction = new ActionBlock<IEnumerable<ExpiringScreeningWrapper>>(UpdateNotifiedFlagsAsync);
            _batchBlock.LinkTo(notifiationSentAction, new DataflowLinkOptions { PropagateCompletion = true });
            _emailSender = new ActionBlock<ExpiringScreeningWrapper>(SendNotificationAsync);

            _emailSender.Completion.ContinueWith(x => _batchBlock.Complete());
        }

        public async Task NotifyEmployees()
        {
            var data = await _query.ExecuteAsync().ConfigureAwait(false);
            await SetInprogressAsync(data).ConfigureAwait(false);

            foreach (var expiration in data)
            {
                _emailSender.Post(expiration);
            }
            _emailSender.Complete();
            await _emailSender.Completion.ConfigureAwait(false);

            _logger.LogInformation(1, $"Notifications sent to {data.Count()} employees");
        }

        private Task SetInprogressAsync(IEnumerable<ExpiringScreeningWrapper> data)
        {
            var screenings = data.Select(x => x.EmployeeScreening).ToList();
            return _updater.SetInProgressAsync(screenings);
        }

        private Task UpdateNotifiedFlagsAsync(IEnumerable<ExpiringScreeningWrapper> data)
        {
            var screenings = data.Select(x => x.EmployeeScreening).ToList();
            return _updater.SetNotifiedDateAsync(screenings, DateTime.UtcNow);
        }

        private async Task SendNotificationAsync(ExpiringScreeningWrapper payload)
        {
            // TODO Add error handling and reset notification progress flags

            var message = $"Your screening ({payload.EmployeeScreening.Screening.Type}) has expired";
            await _notifier.NotifyAsync(payload.EmployeeScreening.Employee, message).ConfigureAwait(false);
            _batchBlock.Post(payload);
        }
    }
}
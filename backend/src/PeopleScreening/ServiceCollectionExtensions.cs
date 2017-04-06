using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeopleScreening.Config;
using PeopleScreening.Data;
using PeopleScreening.Email;
using PeopleScreening.Services;

namespace PeopleScreening
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddScreeningServices(this IServiceCollection services, IConfigurationRoot config)
        {
            services.AddDbContext<PeopleScreeningContext>(options => options.UseSqlServer(config["Data:ConnectionString"]));
            services.AddScoped<IQuery<LastScreeningExpirationReportDto>, LastScreeningExpirationQuery>();
            services.AddScoped<IQuery<ExpiringScreeningWrapper>, ExpiringScreeningQuery>();
            services.AddScoped<SmtpClientFactory>();
            services.AddScoped<INotifier, EmailNotifier>();
            services.AddScoped<ExpiredScreeningsNotifier>();
            services.AddScoped<ScreeningNotificationUpdater>();

            services.Configure<SmtpConfig>(smtpConfig => { });

            return services;
        }
    }
}
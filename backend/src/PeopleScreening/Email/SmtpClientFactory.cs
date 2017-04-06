using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using PeopleScreening.Config;

namespace PeopleScreening.Email
{
    public class SmtpClientFactory
    {
        private readonly IOptions<SmtpConfig> _smtpOptions;
        private readonly IHostingEnvironment _env;

        public SmtpClientFactory(IOptions<SmtpConfig> smtpOptions, IHostingEnvironment env)
        {
            _smtpOptions = smtpOptions;
            _env = env;
        }

        public ISmtpClient CreateClient()
        {
            if (_env.IsDevelopment())
                return new DummySmtpClient();

            throw new NotImplementedException();
        }
    }
}
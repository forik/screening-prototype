using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PeopleScreening.Data;

namespace PeopleScreening
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScreeningServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddFile("./logs/log-{Date}.txt");

            // Redirect all 404 requests to index.html
            // so that angular routing could catch routes
            app.Use(async (context, next) =>
            {
                await next().ConfigureAwait(false);

                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/";
                    await next().ConfigureAwait(false);
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseFileServer(enableDirectoryBrowsing: false);

            app.UseMvc();

            SeedDatabase(app);
        }

        private static void SeedDatabase(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetService<PeopleScreeningContext>();
            context.Database.EnsureCreated();

            var dbSeed = new DatabaseSeed(context);
            dbSeed.Seed();
        }
    }
}

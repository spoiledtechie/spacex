using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using SpaceX.Library.Api.LaunchPad;
using SpaceX.Library.Settings;

namespace SpaceX.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(con => Configuration.GetSection("AppSettings").Bind(con));
            var appSettings = Configuration.GetValue<int>("AppSettings:SpaceXApiVersion");

            //adds the launch pad service.
            //can be traded out with the repository here when the api moves to a database version.
            services.Add(new ServiceDescriptor(typeof(ILaunchPadService), new LaunchPadService(appSettings)));
            //adds the rest of the IOC managers.
            services.AddTransient<ILaunchPadManager, LaunchPadManager>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            ILaunchPadService launch)
        {

            //creates logger.
            loggerFactory.AddSerilog();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheEviction.Entities.Models;
using TheEviction.Entities.ViewModels;

namespace TheEviction
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
            services.AddMvc();
            // The context is typically configured in Startup.cs with the connection string being read from configuration. 
            // Note the GetConnectionString() method looks for a configuration value whose key is ConnectionStrings:<connection string name>
            services.AddDbContext<EvictionDevContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EvictionDevConnection")));

            // I want to create it once per request cycle, and AddScoped is going to allow me to do that.
            services.AddScoped<IClientRepository, ClientRepository>();

            //Transient is going to create this every time we need it, and we're going to inject it directly in the configure method.
            services.AddTransient<ClientContextSeedData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ClientContextSeedData seeder, ILoggerFactory factory)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<ClientViewModel, Client>().ReverseMap();  // ClientViewModel as my source, and I wanna return a Client.
            });

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                factory.AddDebug(LogLevel.Information);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                factory.AddDebug(LogLevel.Error);
            }

            // For wwwroot directory.
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "Client",
                    template: "{controller=Client}/{action=Index}/{id?}");
            });

            seeder.EnsureSeedData().Wait();
        }
    }
}

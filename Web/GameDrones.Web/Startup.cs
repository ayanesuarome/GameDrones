using System.Reflection;
using GameDrones.Data;
using GameDrones.Data.Matches;
using GameDrones.Data.Players;
using GameDrones.Service.Matches;
using GameDrones.Service.Players;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Serilog;
using FluentValidation.AspNetCore;
using GameDrones.Web.Validators;

namespace GameDrones.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false);

            Configuration = configurationBuilder.Build();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.RollingFile(new Serilog.Formatting.Json.JsonFormatter(), System.IO.Path.Combine(env.ContentRootPath, "logs\\log-{Date}.ndjson"))
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<GameStatisticsModelValidator>();
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });

            // Framework services
            services.AddTransient<IPlayerService, PlayerService>()
            .AddTransient<IMatchService, MatchService>()
            .AddTransient<IPlayerRepository, PlayerRepository>()
            .AddTransient<IMatchRepository, MatchRepository>()
            .AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // For repositories and data access
            services.AddScoped<IDbContext>(_ => new GameDroneContext(Configuration.GetConnectionString("DefaultConnection")));

            services.AddLogging();

            var serviceProvider = services.BuildServiceProvider();
            
            using (var context = serviceProvider.GetService<IDbContext>())
            {
                context.Database.EnsureCreated();
            }

            // For cache
            //services.AddSingleton<>();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            loggerFactory.AddNLog();

            app.UseHttpsRedirection()
                .UseStaticFiles()
                .UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            })
            .UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}

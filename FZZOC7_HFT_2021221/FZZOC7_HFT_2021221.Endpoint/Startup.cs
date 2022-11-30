using FZZOC7_HFT_2021221.Data;
using FZZOC7_HFT_2021221.Endpoint.Services;
using FZZOC7_HFT_2021221.Logic;
using FZZOC7_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FZZOC7_HFT_2021221.Endpoint
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IPlayerLogic, PlayerLogic>();
            services.AddTransient<IClubLogic, ClubLogic>();
            services.AddTransient<ILeagueLogic, LeagueLogic>();

            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IClubRepository, ClubRepository>();
            services.AddTransient<ILeagueRepository, LeagueRepository>();

            services.AddSignalR();

            services.AddSingleton<FootballDbContext, FootballDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("https://localhost:44377"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}

using System.IO;
using AutoMapper;
using Data;
using LifeTracker.Business;
using LifeTracker.Business.Domain;
using LifeTracker.Business.Domain.Interfaces;
using LifeTracker.Data;
using LifeTracker.Data.Repositories;
using LifeTracker.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LifeTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ILifeTrackerDBContext, LifeTrackerDBContext>(builder =>
        builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Repositories
            services.AddTransient<IUserRepository, UserRepository>();

            // Domains
            services.AddTransient<IUserDomain, UserDomain>();

            // AutoMapper
            var mapConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            services.AddSingleton(mapConfig.CreateMapper());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

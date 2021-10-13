using AutoMapper;
using Data;
using LifeTracker.Business;
using LifeTracker.Business.Domain;
using LifeTracker.Business.Domain.Interfaces;
using LifeTracker.Business.Options;
using LifeTracker.Data;
using LifeTracker.Data.Entities;
using LifeTracker.Data.Repositories;
using LifeTracker.Data.Repositories.Interfaces;
using LifeTrackerApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

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

            // DB connection
            services.AddDbContext<LifeTrackerDBContext>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<UserEntity, IdentityRole>()
            .AddRoles<IdentityRole>()
           .AddEntityFrameworkStores<LifeTrackerDBContext>();


            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            // Auth
            var authOptionsSection = Configuration.GetSection("Auth");
            services.Configure<AuthOption>(authOptionsSection);

            var authOptions = authOptionsSection.Get<AuthOption>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.RequireHttpsMetadata = true;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = authOptions.SymmetricSecurityKey,

                      ValidateAudience = true,
                      ValidAudience = authOptions.Audience,

                      ValidateIssuer = true,
                      ValidIssuer = authOptions.Issuer,

                      ValidateLifetime = true
                  };
              });

            // CORS 
            var frontOptions = Configuration.GetSection("Front").Get<FrontOption>();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .AllowCredentials()
                      .WithExposedHeaders("Content-Disposition")
                      .WithOrigins(frontOptions.Address);
                });
            });

            // Repositories
            services.AddTransient<ILifeTrackerDBContext, LifeTrackerDBContext>();
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

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

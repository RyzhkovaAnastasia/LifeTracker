using LifeTracker.Business;
using LifeTracker.Business.Options;
using LifeTrackerApi;
using LifeTrackerApi.Controllers.MiddlewareException;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Extensions.Logging;
using System.Net;
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

            // Auth
            var authOptionsSection = Configuration.GetSection("Auth");
            services.Configure<AuthOption>(authOptionsSection);

            var authOptions = authOptionsSection.Get<AuthOption>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
              {
                  options.SaveToken = true;
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

            BusinessLogicLayerConfig.SerivesDIConfig(services, Configuration);

            //NLog
            var logConfig = Configuration.GetSection("NLog");
            LogManager.Configuration = new NLogLoggingConfiguration(logConfig);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionMiddleware>();

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

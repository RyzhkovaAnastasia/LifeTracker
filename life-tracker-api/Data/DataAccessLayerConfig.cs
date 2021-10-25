using Data;
using LifeTracker.Data.Entities;
using LifeTracker.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LifeTracker.Data
{
    public static class DataAccessLayerDIConfig
    {
        public static void SerivesDIConfig(IServiceCollection services, IConfiguration configuration)
        {

            // DB connection
            services.AddDbContext<LifeTrackerDBContext>(builder =>
                builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<UserEntity, IdentityRole<Guid>>()
            .AddRoles<IdentityRole<Guid>>()
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

            // Repositories
            services.AddTransient<ILifeTrackerDBContext, LifeTrackerDBContext>();
            services.AddTransient<IHabitRepository, HabitRepository>();
            services.AddTransient<IToDoRepository, ToDoRepository>();
            services.AddTransient<IDailyRepository, DailyRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<IRewardRepository, RewardRepository>();
        }
    }
}

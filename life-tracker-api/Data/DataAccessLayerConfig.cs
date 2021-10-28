using Data;
using LifeTracker.Data.Entities;
using LifeTracker.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
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

            services.AddIdentityCore<UserEntity>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireLowercase = true;
            }).AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<LifeTrackerDBContext>()
            .AddDefaultTokenProviders();

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

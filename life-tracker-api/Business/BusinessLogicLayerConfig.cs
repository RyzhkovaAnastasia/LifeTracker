using AutoMapper;
using LifeTracker.Business.Domain;
using LifeTracker.Business.Domain.Interfaces;
using LifeTracker.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LifeTracker.Business
{
    public static class BusinessLogicLayerConfig
    {
        public static void SerivesDIConfig(IServiceCollection services, IConfiguration configuration)
        {
            DataAccessLayerDIConfig.SerivesDIConfig(services, configuration);
            // Domains
            services.AddTransient<IUserDomain, UserDomain>();

            // AutoMapper
            var mapConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            services.AddSingleton(mapConfig.CreateMapper());
        }
    }
}

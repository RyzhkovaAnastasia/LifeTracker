using AutoMapper;
using LifeTracker.Business.Models;
using LifeTracker.Data.Entities;

namespace LifeTracker.Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserViewModel>().ReverseMap();
        }
    }
}

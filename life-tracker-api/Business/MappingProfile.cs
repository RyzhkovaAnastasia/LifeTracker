﻿using AutoMapper;
using LifeTracker.Business.Models;
using LifeTracker.Business.ViewModels;
using LifeTracker.Data.DTO;
using LifeTracker.Data.Entities;

namespace LifeTracker.Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserViewModel>().ReverseMap();
            CreateMap<LoginDTO, LoginViewModel>().ReverseMap();
        }
    }
}

using AutoMapper;
using LifeTracker.Business.CustomException;
using LifeTracker.Business.Domain.Interfaces;
using LifeTracker.Business.ViewModels;
using LifeTracker.Data.Entities;
using LifeTracker.Data.Repositories;
using System;
using System.Collections.Generic;

namespace LifeTracker.Business.Domain
{
    public class HabitDomain : IHabitDomain
    {
        private readonly IHabitRepository _HabitRepository;
        private readonly IMapper _mapper;

        void CheckUserId(Guid userId, Guid userIdClaim)
        {
            if (userId == userIdClaim)
            {
                throw new ForbiddenException("Not daily task owner");
            }
        }

        public HabitDomain(IHabitRepository HabitRepository, IMapper mapper)
        {
            _HabitRepository = HabitRepository;
            _mapper = mapper;
        }
        public void Create(HabitViewModel item, Guid userId)
        {
            CheckUserId(item.UserId, userId);
            _HabitRepository.Create(_mapper.Map<HabitEntity>(item));
        }

        public void Delete(int id, Guid userId)
        {
            var item = Get(id);
            CheckUserId(item.UserId, userId);
            _HabitRepository.Delete(id);
        }

        public HabitViewModel Get(int id)
        {
            return _mapper.Map<HabitViewModel>(_HabitRepository.Get(id));
        }

        public IEnumerable<HabitViewModel> GetAll(Guid userId)
        {
            return _mapper.Map<IEnumerable<HabitViewModel>>(_HabitRepository.GetAll(userId));
        }

        public void Update(HabitViewModel item, Guid userId)
        {
            CheckUserId(item.UserId, userId);
            _HabitRepository.Update(_mapper.Map<HabitEntity>(item));
        }
    }
}

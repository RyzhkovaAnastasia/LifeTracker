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
    public class DailyDomain : IDailyDomain
    {
        private readonly IDailyRepository _dailyRepository;
        private readonly IMapper _mapper;

        public DailyDomain(IDailyRepository dailyRepository, IMapper mapper)
        {
            _dailyRepository = dailyRepository;
            _mapper = mapper;
        }

        void CheckUserId(Guid userId, Guid userIdClaim)
        {
            if (userId == userIdClaim)
            {
                throw new ForbiddenException("Not daily task owner");
            }
        }

        public void Create(DailyViewModel item, Guid userId)
        {
            CheckUserId(item.UserId, userId);
            _dailyRepository.Create(_mapper.Map<DailyEntity>(item));
        }

        public void Delete(int id, Guid userId)
        {
            var item = Get(id);
            CheckUserId(item.UserId, userId);
            _dailyRepository.Delete(id);
        }

        public DailyViewModel Get(int id)
        {
            return _mapper.Map<DailyViewModel>(_dailyRepository.Get(id));
        }

        public IEnumerable<DailyViewModel> GetAll(Guid userId)
        {
            return _mapper.Map<IEnumerable<DailyViewModel>>(_dailyRepository.GetAll(userId));
        }

        public void Update(DailyViewModel item, Guid userId)
        {
            CheckUserId(item.UserId, userId);
            _dailyRepository.Update(_mapper.Map<DailyEntity>(item));
        }
    }
}

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
    public class RewardDomain : IRewardDomain
    {
        private readonly IRewardRepository _RewardRepository;
        private readonly IMapper _mapper;

        public RewardDomain(IRewardRepository RewardRepository, IMapper mapper)
        {
            _RewardRepository = RewardRepository;
            _mapper = mapper;
        }

        void CheckUserId(Guid userId, Guid userIdClaim)
        {
            if (userId == userIdClaim)
            {
                throw new ForbiddenException("Not daily task owner");
            }
        }

        public void Create(RewardViewModel item, Guid userId)
        {
            CheckUserId(item.UserId, userId);
            _RewardRepository.Create(_mapper.Map<RewardEntity>(item));
        }

        public void Delete(int id, Guid userId)
        {
            var item = Get(id);
            CheckUserId(item.UserId, userId);
            _RewardRepository.Delete(id);
        }

        public RewardViewModel Get(int id)
        {
            return _mapper.Map<RewardViewModel>(_RewardRepository.Get(id));
        }

        public IEnumerable<RewardViewModel> GetAll(Guid userId)
        {
            return _mapper.Map<IEnumerable<RewardViewModel>>(_RewardRepository.GetAll(userId));
        }

        public void Update(RewardViewModel item, Guid userId)
        {
            CheckUserId(item.UserId, userId);
            _RewardRepository.Update(_mapper.Map<RewardEntity>(item));
        }
    }
}

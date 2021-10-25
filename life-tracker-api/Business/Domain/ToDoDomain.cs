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
    public class ToDoDomain : IToDoDomain
    {
        private readonly IToDoRepository _ToDoRepository;
        private readonly IMapper _mapper;

        void CheckUserId(Guid userId, Guid userIdClaim)
        {
            if (userId == userIdClaim)
            {
                throw new ForbiddenException("Not daily task owner");
            }
        }

        public ToDoDomain(IToDoRepository ToDoRepository, IMapper mapper)
        {
            _ToDoRepository = ToDoRepository;
            _mapper = mapper;
        }
        public void Create(ToDoViewModel item, Guid userId)
        {
            CheckUserId(item.UserId, userId);
            _ToDoRepository.Create(_mapper.Map<ToDoEntity>(item));
        }

        public void Delete(int id, Guid userId)
        {
            var item = Get(id);
            CheckUserId(item.UserId, userId);
            _ToDoRepository.Delete(id);
        }

        public ToDoViewModel Get(int id)
        {
            return _mapper.Map<ToDoViewModel>(_ToDoRepository.Get(id));
        }

        public IEnumerable<ToDoViewModel> GetAll(Guid userId)
        {
            return _mapper.Map<IEnumerable<ToDoViewModel>>(_ToDoRepository.GetAll(userId));
        }

        public void Update(ToDoViewModel item, Guid userId)
        {
            CheckUserId(item.UserId, userId);
            _ToDoRepository.Update(_mapper.Map<ToDoEntity>(item));
        }
    }
}

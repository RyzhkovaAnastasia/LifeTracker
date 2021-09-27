using AutoMapper;
using LifeTracker.Business.Models;
using LifeTracker.Data.Repositories;
using System.Collections.Generic;
using LifeTracker.Data.Repositories.Interfaces;
using LifeTracker.Data.Entities;
using LifeTracker.Business.Domain.Interfaces;

namespace LifeTracker.Business.Domain
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserDomain(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<UserViewModel> Get() =>
          _mapper.Map<IEnumerable<UserEntity>, IEnumerable<UserViewModel>>(_userRepository.Get());
    }
}

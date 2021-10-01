using AutoMapper;
using LifeTracker.Business.Models;
using System.Collections.Generic;
using LifeTracker.Data.Repositories.Interfaces;
using LifeTracker.Data.Entities;
using LifeTracker.Business.Domain.Interfaces;
using LifeTracker.Business.ViewModels;

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

        public string RegisterUser(RegisterViewModel user)
        {
            var userViewModel = new UserViewModel() { Email = user.Email, PasswordHash = user.Password, UserName = user.Name };
             var userEntity = _mapper.Map<UserViewModel, UserEntity>(userViewModel);

            return _userRepository.RegisterUser(userEntity);
        }

        public bool LoginUser(LoginViewModel user)
        {
            var userViewModel = new UserViewModel() { Email = user.Email, PasswordHash = user.Password };
            var userEntity = _mapper.Map<UserViewModel, UserEntity>(userViewModel);

            return _userRepository.LoginUser(userEntity);
        }

        public string LogoutUser() => _userRepository.LogoutUser();
    }
}

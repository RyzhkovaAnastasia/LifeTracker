using AutoMapper;
using LifeTracker.Business.Models;
using System.Collections.Generic;
using LifeTracker.Data.Repositories.Interfaces;
using LifeTracker.Data.Entities;
using LifeTracker.Business.Domain.Interfaces;
using LifeTracker.Business.ViewModels;
using LifeTracker.Data.DTO;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using LifeTracker.Business.Options;
using Microsoft.Extensions.Options;
using System;
using LifeTracker.Business.CustomException;

namespace LifeTracker.Business.Domain
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IOptions<AuthOption> _authOptions;

        public UserDomain(IUserRepository userRepository, IMapper mapper, IOptions<AuthOption> authOptions)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authOptions = authOptions;
        }

        public IEnumerable<UserViewModel> GetUsers() =>
          _mapper.Map<IEnumerable<UserEntity>, IEnumerable<UserViewModel>>(_userRepository.GetUsers());

        public string RegisterUser(RegisterViewModel user)
        {
            try
            {
                var userViewModel = new UserViewModel() { Email = user.Email, PasswordHash = user.Password, UserName = user.UserName };
                var userEntity = _mapper.Map<UserViewModel, UserEntity>(userViewModel);

                return _userRepository.RegisterUser(userEntity);
            }
            catch(Exception e)
            {
                throw new RegistrationException(e.Message);
            }
        }

        public string LoginUser(LoginViewModel user)
        {
            try
            {
                var userEntity = _mapper.Map<LoginViewModel, LoginDTO>(user);
                return _userRepository.LoginUser(userEntity);
            }
            catch
            {
                throw new LoginException("Invalid credential");
            }
        }

        public void LogoutUser() => _userRepository.LogoutUser();

        public UserViewModel GetUser(string userId) => _mapper.Map<UserEntity, UserViewModel>(_userRepository.GetUser(userId));

        public string GenerateJWT(string userId)
        {
            var user = GetUser(userId);
            var authOptions = _authOptions.Value;

            var securityKey = authOptions.SymmetricSecurityKey;
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              authOptions.Issuer,
              authOptions.Audience,
              new[]
              {
                  new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                  new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                  new Claim(JwtRegisteredClaimNames.Email, user.Email),
              },
              expires: DateTime.Now.AddMinutes(authOptions.TokenLifetime),
              signingCredentials: credentials);
            Console.WriteLine(new JwtSecurityTokenHandler().WriteToken(token));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

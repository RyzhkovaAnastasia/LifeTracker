using AutoMapper;
using LifeTracker.Business.Models;
using System.Collections.Generic;
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
using Microsoft.AspNetCore.Identity;

namespace LifeTracker.Business.Domain
{
    public class UserDomain : IUserDomain
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;
        private readonly IOptions<AuthOption> _authOptions;

        public UserDomain(UserManager<UserEntity> userManager, IMapper mapper, IOptions<AuthOption> authOptions)
        {
            _userManager = userManager;
            _mapper = mapper;
            _authOptions = authOptions;
        }

        public IEnumerable<UserViewModel> GetUsers() =>
          _mapper.Map<IEnumerable<UserEntity>, IEnumerable<UserViewModel>>(_userManager.Users);

        public string RegisterUser(RegisterViewModel user)
        {
            try
            {
                var userEntity = _mapper.Map<RegisterViewModel, UserEntity>(user);
                _userManager.CreateAsync(userEntity, user.Password);
                return _userManager.GetUserIdAsync(userEntity).Result;
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
                var userByEmail =_userManager.FindByEmailAsync(userEntity.Email).Result;

                if (_userManager.CheckPasswordAsync(userByEmail, user.Password).Result)
                {
                    return _userManager.GetUserIdAsync(userByEmail).Result;
                }
                throw new LoginException("Invalid password");
            }
            catch
            {
                throw new LoginException("Invalid credentials");
            }
        }

        public UserViewModel GetUser(string userId) 
            => _mapper.Map<UserEntity, UserViewModel>(_userManager.FindByIdAsync(userId).Result);

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

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

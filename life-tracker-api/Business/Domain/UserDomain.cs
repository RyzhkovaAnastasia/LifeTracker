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
using System.Linq;

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

        public List<UserViewModel> GetUsers() =>
          _mapper.Map<IEnumerable<UserEntity>, IEnumerable<UserViewModel>>(_userManager.Users).ToList();

        public UserViewModel RegisterUser(RegisterViewModel user)
        {
            UserEntity userEntity = _mapper.Map<RegisterViewModel, UserEntity>(user);
            var result = _userManager.CreateAsync(userEntity, user.Password).Result;

            if (!result.Succeeded) throw new RegistrationException(string.Join("\n", result.Errors.Select(x => x.Description)));

            return _mapper.Map<UserViewModel>(_userManager.FindByEmailAsync(user.Email).Result);
        }

        public UserViewModel LoginUser(LoginViewModel user)
        {
            try
            {
                var userEntity = _mapper.Map<LoginViewModel, LoginDTO>(user);
                var userByEmail = _userManager.FindByEmailAsync(userEntity.Email).Result;

                if (_userManager.CheckPasswordAsync(userByEmail, user.Password).Result)
                {
                    return _mapper.Map<UserViewModel>(_userManager.FindByEmailAsync(user.Email).Result);
                }
                throw new LoginException("Invalid password");
            }
            catch
            {
                throw new LoginException("Invalid email");
            }
        }

        public UserViewModel GetUser(Guid userId)
            => _mapper.Map<UserEntity, UserViewModel>(_userManager.FindByIdAsync(userId.ToString()).Result);

        public UserAuthenticatedViewModel GenerateJWT(UserViewModel user)
        {
            var authOptions = _authOptions.Value;

            var securityKey = authOptions.SymmetricSecurityKey;
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              authOptions.Issuer,
              authOptions.Audience,
              new[]
              {
                  new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                  new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                  new Claim(JwtRegisteredClaimNames.Email, user.Email)
              },
              expires: DateTime.Now.AddMinutes(authOptions.TokenLifetime),
              signingCredentials: credentials);

            var userWithToken = _mapper.Map<UserAuthenticatedViewModel>(user);
            userWithToken.JWT = new JwtSecurityTokenHandler().WriteToken(token);
            return userWithToken;
        }
    }
}

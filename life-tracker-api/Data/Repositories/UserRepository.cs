using LifeTracker.Data.DTO;
using LifeTracker.Data.Entities;
using LifeTracker.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeTracker.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ILifeTrackerDBContext _context;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public UserRepository(ILifeTrackerDBContext context, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IEnumerable<UserEntity> GetUsers() => _context.Accounts;

        public UserEntity GetUser(string userId) => _context.Accounts.Find(userId);

        public string RegisterUser(UserEntity user)
        {
            Task<IdentityResult> result = default;
            try
            {
                result = _userManager.CreateAsync(user, user.PasswordHash);
                var userId = _userManager.FindByEmailAsync(user.Email).Result.Id;
                return userId;
            }
            catch 
            {
                throw new AggregateException(string.Join("\n", result.Result.Errors.Select(x => x.Description)));
            }
        }

        public string LoginUser(LoginDTO credentials)
        {
            Task<SignInResult> result = default;
            try
            {
                var userId = _userManager.FindByEmailAsync(credentials.EmailOrUsername).Result.Id;
                var userLogin = GetUser(userId).UserName ?? credentials.EmailOrUsername;
                result = _signInManager.PasswordSignInAsync(userLogin, credentials.Password, false, false);
                return userId;
            }
            catch
            {
                throw new Exception(result.Exception.Message);
            }
        }

        public void LogoutUser()
        {
            _signInManager.SignOutAsync();
        }
    }
}

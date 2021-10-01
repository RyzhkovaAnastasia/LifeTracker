using LifeTracker.Data.Entities;
using LifeTracker.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

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

        public IEnumerable<UserEntity> Get() => _context.Accounts;

        public string RegisterUser(UserEntity user)
        {
            var result = _userManager.CreateAsync(user, user.PasswordHash);
            return result.Result.Succeeded? string.Empty : result.Result.Errors.ToString();
        }

        public bool LoginUser(UserEntity user)
        {
            
            var result = _signInManager.PasswordSignInAsync(user.Email, user.PasswordHash, user.LockoutEnabled, false);
            return result.Result.Succeeded;
        }

        public string LogoutUser()
        {
            try
            {
                var result = _signInManager.SignOutAsync();
                return string.Empty;
            }
            catch (AggregateException e)
            {
                return e.Message;
            }
        }
    }
}

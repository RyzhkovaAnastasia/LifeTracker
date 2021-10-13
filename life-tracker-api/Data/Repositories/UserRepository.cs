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

        public string RegisterUser(UserEntity user, string password)
        {
            IdentityResult result = default;
            try
            {
                result = _userManager.CreateAsync(user, password).Result;
                return user.Id;
            }
            catch
            {
                throw new AggregateException(string.Join("\n", result.Errors.Select(x => x.Description)));
            }
        }

        public string LoginUser(LoginDTO credentials)
        {
            try
            {
                _signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, false, false).Wait();
                return _userManager.FindByEmailAsync(credentials.Email).Result.Id;
            }
            catch
            {
                throw new Exception();
            }
        }

        public void LogoutUser()
        {
            _signInManager.SignOutAsync();
        }
    }
}

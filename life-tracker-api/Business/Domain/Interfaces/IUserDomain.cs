using LifeTracker.Business.Models;
using LifeTracker.Business.ViewModels;
using System.Collections.Generic;

namespace LifeTracker.Business.Domain.Interfaces
{
    public interface IUserDomain
    {
        public IEnumerable<UserViewModel> GetUsers();
        string RegisterUser(RegisterViewModel user);
        string LoginUser(LoginViewModel user);
        UserViewModel GetUser(string userId);
        string GenerateJWT(string userId);
    }
}

using LifeTracker.Business.Models;
using LifeTracker.Business.ViewModels;

namespace LifeTracker.Business.Domain.Interfaces
{
    public interface IUserDomain
    {
        string RegisterUser(RegisterViewModel user);
        string LoginUser(LoginViewModel user);
        void LogoutUser();
        UserViewModel GetUser(string userId);
        string GenerateJWT(string userId);
    }
}

using LifeTracker.Business.ViewModels;

namespace LifeTracker.Business.Domain.Interfaces
{
    public interface IUserDomain
    {
        string RegisterUser(RegisterViewModel user);
        bool LoginUser(LoginViewModel user);
        string LogoutUser();
    }
}

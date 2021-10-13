using LifeTracker.Data.DTO;
using LifeTracker.Data.Entities;
using System.Collections.Generic;

namespace LifeTracker.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserEntity> GetUsers();
        string RegisterUser(UserEntity user, string password);
        string LoginUser(LoginDTO user);
        void LogoutUser();
        UserEntity GetUser(string userId);
    }
}

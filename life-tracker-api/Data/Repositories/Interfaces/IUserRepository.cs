using LifeTracker.Data.DTO;
using LifeTracker.Data.Entities;
using System.Collections.Generic;

namespace LifeTracker.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserEntity> Get();
        string RegisterUser(UserEntity user);
        bool LoginUser(LoginDTO user);
        string LogoutUser();
    }
}

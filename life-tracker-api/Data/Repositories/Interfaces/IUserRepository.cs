using LifeTracker.Data.Entities;
using System.Collections.Generic;

namespace LifeTracker.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<UserEntity> Get();
    }
}

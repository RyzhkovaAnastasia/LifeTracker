using LifeTracker.Data.Entities;
using LifeTracker.Data.Repositories.Interfaces;
using System.Collections.Generic;

namespace LifeTracker.Data.Repositories
{
    public class UserRepository: IUserRepository
    {
            private readonly ILifeTrackerDBContext _context;

            public UserRepository(ILifeTrackerDBContext context)
            {
                _context = context;
            }

            public IEnumerable<UserEntity> Get() => _context.Users;
    }
}

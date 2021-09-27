using LifeTracker.Business.Models;
using System.Collections.Generic;

namespace LifeTracker.Business.Domain.Interfaces
{
    public interface IUserDomain
    {
        IEnumerable<UserViewModel> Get();
    }
}

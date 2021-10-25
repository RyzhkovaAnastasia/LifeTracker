using LifeTracker.Business.Models;
using LifeTracker.Business.ViewModels;
using System;
using System.Collections.Generic;

namespace LifeTracker.Business.Domain.Interfaces
{
    public interface IUserDomain
    {
        public List<UserViewModel> GetUsers();
        UserViewModel RegisterUser(RegisterViewModel user);
        UserViewModel LoginUser(LoginViewModel user);
        UserViewModel GetUser(Guid userId);
        UserAuthenticatedViewModel GenerateJWT(UserViewModel user);
    }
}

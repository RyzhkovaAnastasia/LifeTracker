using LifeTracker.Business.Models;
using LifeTracker.Business.ViewModels;
using System;
using System.Collections.Generic;

namespace LifeTracker.Business.Domain.Interfaces
{
    public interface IUserDomain
    {
        public List<UserViewModel> GetUsers();
        public UserViewModel GetUser(Guid id);
        public UserViewModel RegisterUser(RegisterViewModel user);
        public UserViewModel LoginUser(LoginViewModel user);
        string GenerateJWT(UserViewModel user);
    }
}

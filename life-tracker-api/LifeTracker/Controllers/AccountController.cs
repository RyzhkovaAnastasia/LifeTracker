using LifeTracker.Business.CustomException;
using LifeTracker.Business.Domain.Interfaces;
using LifeTracker.Business.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LifeTrackerApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IUserDomain _userDomain;
        public AccountController(IUserDomain userDomain)
        {
            _userDomain = userDomain;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegisterViewModel user)
        {
            if (user.Password != user.PasswordConfirm)
            {
                return BadRequest("Password confirm does not match password");
            }

            try
            {
                var userModel = _userDomain.RegisterUser(user);

                return Ok(_userDomain.GenerateJWT(userModel));
            }
            catch (RegistrationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login(LoginViewModel user)
        {
            try
            {
                var userModel = _userDomain.LoginUser(user);
                return Ok(_userDomain.GenerateJWT(userModel));
            }
            catch (LoginException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Users")]
        public IActionResult GetUsers()
        {
            var users = _userDomain.GetUsers();
            return Ok(users);
        }
    }
}

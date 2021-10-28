using LifeTracker.Business.CustomException;
using LifeTracker.Business.Domain.Interfaces;
using LifeTracker.Business.ViewModels;
using LifeTrackerApi.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeTrackerApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserDomain _userDomain;
        public UserController(IUserDomain userDomain)
        {
            _userDomain = userDomain;
        }

        [HttpPost("SignUp")]
        [AllowAnonymous]
        public IActionResult SignUp(RegisterViewModel user)
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

        [HttpPost("SignIn")]
        [AllowAnonymous]
        public IActionResult SignIn(LoginViewModel user)
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

        [HttpGet("User")]
        public IActionResult GetUser()
        {
            var users = _userDomain.GetUser(User.GetId());
            return Ok(users);
        }
    }
}

using LifeTracker.Business.Domain.Interfaces;
using LifeTracker.Business.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LifeTrackerApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUserDomain _userDomain;
        public AccountController(IUserDomain userDomain)
        {
            _userDomain = userDomain;
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel user)
        {
            if(user.Password != user.PasswordConfirm)
            {
                return BadRequest("Password confirm does not match password");
            }
            string errors = _userDomain.RegisterUser(user);

            if (errors.Length == 0)
            {
                return Ok("User was succesfully registered");
            }
            return BadRequest(errors);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel user)
        {
            bool succeses = _userDomain.LoginUser(user);

            if (succeses)
            {
                return Ok("User was succesfully login");
            }
            return BadRequest("Invalid credentials");
        }

        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {
            string error = _userDomain.LogoutUser();
            if (error.Length == 0)
            {
                return Ok();
            }
            return BadRequest(error);
        }
    }
}

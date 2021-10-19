using LifeTracker.Business.CustomException;
using LifeTracker.Business.Domain.Interfaces;
using LifeTracker.Business.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeTrackerApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : Controller
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
                string id = _userDomain.RegisterUser(user);

                return Ok(_userDomain.GenerateJWT(id));
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
                string id = _userDomain.LoginUser(user);
                return Ok(_userDomain.GenerateJWT(id));
            }
            catch (LoginException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Users")]
        public IActionResult GetUsers()
        {
            _userDomain.GetUsers();
            return Ok();
        }
    }
}

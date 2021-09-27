using LifeTracker.Business.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LifeTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDomain _userDomain;

        public UserController(IUserDomain userDomain)
        {
            _userDomain = userDomain;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_userDomain.Get());


    }
}

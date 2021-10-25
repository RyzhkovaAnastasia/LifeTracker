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
    public class HabitController : ControllerBase
    {
        private readonly IHabitDomain _habitDomain;
        public HabitController(IHabitDomain HabitDomain)
        {
            _habitDomain = HabitDomain;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_habitDomain.GetAll(User.GetId()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_habitDomain.Get(id));
        }

        [HttpPost]
        public IActionResult Create(HabitViewModel item)
        {
            _habitDomain.Create(item, User.GetId());
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(HabitViewModel item)
        {
            _habitDomain.Update(item, User.GetId());
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _habitDomain.Delete(id, User.GetId());
            return Ok();
        }
    }
}

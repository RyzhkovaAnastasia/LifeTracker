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
    public class DailyController : ControllerBase
    {
        private readonly IDailyDomain _dailyDomain;
        public DailyController(IDailyDomain dailyDomain)
        {
            _dailyDomain = dailyDomain;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_dailyDomain.GetAll(User.GetId()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_dailyDomain.Get(id));
        }

        [HttpPost]
        public IActionResult Create(DailyViewModel item)
        {
            _dailyDomain.Create(item, User.GetId());
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(DailyViewModel item)
        {
            _dailyDomain.Update(item, User.GetId());
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _dailyDomain.Delete(id, User.GetId());
            return Ok();
        }
    }
}

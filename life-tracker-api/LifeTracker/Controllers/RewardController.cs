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
    public class RewardController : ControllerBase
    {
        private readonly IRewardDomain _rewardDomain;
        public RewardController(IRewardDomain rewardDomain)
        {
            _rewardDomain = rewardDomain;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_rewardDomain.GetAll(User.GetId()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_rewardDomain.Get(id));
        }

        [HttpPost]
        public IActionResult Create(RewardViewModel item)
        {
            _rewardDomain.Create(item, User.GetId());
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(RewardViewModel item)
        {
            _rewardDomain.Update(item, User.GetId());
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _rewardDomain.Delete(id, User.GetId());
            return Ok();
        }
    }
}

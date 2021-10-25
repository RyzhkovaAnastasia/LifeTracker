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
    public class TagController : ControllerBase
    {
        private readonly ITagDomain _tagDomain;
        public TagController(ITagDomain tagDomain)
        {
            _tagDomain = tagDomain;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_tagDomain.GetAll(User.GetId()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_tagDomain.Get(id));
        }

        [HttpPost]
        public IActionResult Create(TagViewModel item)
        {
            _tagDomain.Create(item, User.GetId());
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(TagViewModel item)
        {
            _tagDomain.Update(item, User.GetId());
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tagDomain.Delete(id, User.GetId());
            return Ok();
        }
    }
}

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
    public class ToDoController : ControllerBase
    {
        private readonly IToDoDomain _toDoDomain;
        public ToDoController(IToDoDomain toDoDomain)
        {
            _toDoDomain = toDoDomain;
        }

         [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_toDoDomain.GetAll(User.GetId()));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_toDoDomain.Get(id));
        }

        [HttpPost]
        public IActionResult Create(ToDoViewModel item)
        {
            _toDoDomain.Create(item, User.GetId());
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(ToDoViewModel item)
        {
            _toDoDomain.Update(item, User.GetId());
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _toDoDomain.Delete(id, User.GetId());
            return Ok();
        }
    }
}

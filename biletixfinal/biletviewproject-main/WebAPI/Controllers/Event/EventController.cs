using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Event
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _eventService.GetEvents();
            return Ok(result);
        }
    }
}

using Application.Services;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Event
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatedEventController : ControllerBase
    {
        private readonly ISeatedEventService _seatedEventService;

        public SeatedEventController(ISeatedEventService seatedEventService)
        {
            _seatedEventService = seatedEventService;
        }

        #region # Seated Events
        [HttpGet]
        public async Task<ActionResult<List<SeatedEvent>>> GetSeatedEvents()
        {
            var events = await _seatedEventService.GetEventsAsync();
            return Ok(events);
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<SeatedEvent>> GetSeatedEvent(Guid eventId)
        {
            var eventItem = await _seatedEventService.GetEventByIdAsync(eventId);
            if (eventItem == null)
            {
                return NotFound();
            }

            return Ok(eventItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeatedEvent(/*[FromForm]List<IFormFile> files,*/ SeatedEventCreateDto eventItem)
        {
            
            var result = await _seatedEventService.CreateEventAsync(/*files,*/ eventItem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{eventId}")]
        public async Task<IActionResult> UpdateSeatedEvent(SeatedEvent eventItem)
        {
            var eventExist = await _seatedEventService.GetEventByIdAsync(eventItem.Id);
            if (eventExist == null)
            {
                return NotFound();
            }

            var result = await _seatedEventService.UpdateEventAsync(eventItem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteSeatedEvent(Guid eventId)
        {
            var eventItem = await _seatedEventService.GetEventByIdAsync(eventId);

            if (eventItem == null)
            {
                return NotFound();
            }

            var result = await _seatedEventService.DeleteEventAsync(eventId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        #endregion
    }
}

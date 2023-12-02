using Application.Services;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Event
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandingEventController : ControllerBase
    {
        private readonly IStandingEventService _standingEventService;

        public StandingEventController(IStandingEventService standingEventService)
        {
            _standingEventService = standingEventService;
        }

        #region # Standing Events
        [HttpGet]
        public async Task<ActionResult<List<StandingEvent>>> GetStandingEvents()
        {
            var events = await _standingEventService.GetEventsAsync();
            return Ok(events);
        }

        [HttpGet("{eventId}")]
        public async Task<ActionResult<StandingEvent>> GetStandingEvent(Guid eventId)
        {
            var eventItem = await _standingEventService.GetEventByIdAsync(eventId);
            if (eventItem == null)
            {
                return NotFound();
            }

            return Ok(eventItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStandingEvent(/*[FromQuery] List<IFormFile> files,*/ StandingEventCreateDto eventItem)
        {
            var result = await _standingEventService.CreateEventAsync(/*files,*/ eventItem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{eventId}")]
        public async Task<IActionResult> UpdateStandingEvent(StandingEvent eventItem)
        {
            var eventExist = await _standingEventService.GetEventByIdAsync(eventItem.Id);
            if (eventExist == null)
            {
                return NotFound();
            }

            var result = await _standingEventService.UpdateEventAsync(eventItem);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{eventId}")]
        public async Task<IActionResult> DeleteStandingEvent(Guid eventId)
        {
            var eventItem = await _standingEventService.GetEventByIdAsync(eventId);

            if (eventItem == null)
            {
                return NotFound();
            }

            var result = await _standingEventService.DeleteEventAsync(eventId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        #endregion
    }
}

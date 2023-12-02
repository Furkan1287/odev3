using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Event
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventImageController : ControllerBase
    {
        readonly IEventImageService _eventImageService;

        public EventImageController(IEventImageService eventImageService)
        {
            _eventImageService = eventImageService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadEventImage([FromForm] EventImageUploadDto? eventImageUploadDto)
        {
            var result = await _eventImageService.UploadImage(eventImageUploadDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

using Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.Venue
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVenues()
        {
            var result = await _venueService.GetVenues();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenueById(Guid id)
        {
            var result = await _venueService.GetVenueById(id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddVenue([FromBody] VenueDetailDto venueDto)
        {
            var result = await _venueService.AddVenue(venueDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenue(Guid id, [FromBody] VenueDetailDto updatedVenueDto)
        {
            var result = await _venueService.UpdateVenue(id, updatedVenueDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenue(Guid id)
        {
            var result = await _venueService.DeleteVenue(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

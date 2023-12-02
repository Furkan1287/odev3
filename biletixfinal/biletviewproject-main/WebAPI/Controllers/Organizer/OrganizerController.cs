using Application.Services;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizerController : ControllerBase
    {
        private readonly IOrganizerService _organizerService;

        public OrganizerController(IOrganizerService organizerService)
        {
            _organizerService = organizerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganizers()
        {
            var result = await _organizerService.GetOrganizers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizerById(Guid id)
        {
            var result = await _organizerService.GetOrganizerById(id);
            if (result is NotFoundCommandResult)
            {
                return NotFound(result);
            }
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrganizer(OrganizerDetailDto organizerDto)
        {
            var result = await _organizerService.AddOrganizer(organizerDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrganizer(Guid id, OrganizerDetailDto updatedOrganizerDto)
        {
            var result = await _organizerService.UpdateOrganizer(id, updatedOrganizerDto);
            if (result is NotFoundCommandResult)
            {
                return NotFound(result);
            }
            
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganizer(Guid id)
        {
            var result = await _organizerService.DeleteOrganizer(id);
            if (result is NotFoundCommandResult)
            {
                return NotFound(result);
            }
            
            return Ok(result);
        }
    }
}

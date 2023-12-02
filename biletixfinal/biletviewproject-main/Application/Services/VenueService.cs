using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Shared.Repository;
using Shared.Utils.Result;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IVenueService
    {
        Task<CommandResult<IEnumerable<VenueDetailDto>>> GetVenues();
        Task<CommandResult<VenueDetailDto>> GetVenueById(Guid id);
        Task<CommandResult> AddVenue(VenueDetailDto venueDto);
        Task<CommandResult> UpdateVenue(Guid id, VenueDetailDto updatedVenueDto);
        Task<CommandResult> DeleteVenue(Guid id);
    }

    public class VenueService : IVenueService
    {
        private readonly IGenericRepositoryAsync<Venue> _venueRepository;
        private readonly IMapper _mapper;

        Expression<Func<Venue, object>>[] includes = new Expression<Func<Venue, object>>[]
        {
         
            v => v.Events
        };

        public VenueService(IGenericRepositoryAsync<Venue> venueRepository, IMapper mapper)
        {
            _venueRepository = venueRepository;
            _mapper = mapper;
        }

        public async Task<CommandResult<IEnumerable<VenueDetailDto>>> GetVenues()
        {
            var venueList = await _venueRepository.GetAllAsync(includes);
            var data = _mapper.Map<IEnumerable<VenueDetailDto>>(venueList);
            return new SuccessCommandResult<IEnumerable<VenueDetailDto>>(data);
        }

        public async Task<CommandResult<VenueDetailDto>> GetVenueById(Guid id)
        {
            var venue = await _venueRepository.GetByIdAsync(id, includes);
            if (venue == null)
            {
                return new NotFoundCommandResult<VenueDetailDto>("Venue not found");
            }

            var data = _mapper.Map<VenueDetailDto>(venue);
            return new SuccessCommandResult<VenueDetailDto>(data);
        }

        public async Task<CommandResult> AddVenue(VenueDetailDto venueDto)
        {
            var venue = _mapper.Map<Venue>(venueDto);
            await _venueRepository.AddAsync(venue);
            return new SuccessCommandResult("Venue added successfully");
        }

        public async Task<CommandResult> UpdateVenue(Guid id, VenueDetailDto updatedVenueDto)
        {
            var venue = await _venueRepository.GetByIdAsync(id);
            if (venue == null)
            {
                return new NotFoundCommandResult("Venue not found");
            }

            _mapper.Map(updatedVenueDto, venue);
            await _venueRepository.UpdateAsync(venue);
            return new SuccessCommandResult("Venue updated successfully");
        }

        public async Task<CommandResult> DeleteVenue(Guid id)
        {
            var venue = await _venueRepository.GetByIdAsync(id);
            if (venue == null)
            {
                return new NotFoundCommandResult("Venue not found");
            }

            await _venueRepository.DeleteAsync(venue);
            return new SuccessCommandResult("Venue deleted successfully");
        }
    }
}

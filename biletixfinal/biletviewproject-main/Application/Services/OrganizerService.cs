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
    public interface IOrganizerService
    {
        Task<CommandResult<IEnumerable<OrganizerDetailDto>>> GetOrganizers();
        Task<CommandResult<OrganizerDetailDto>> GetOrganizerById(Guid id);
        Task<CommandResult> AddOrganizer(OrganizerDetailDto organizerDto);
        Task<CommandResult> UpdateOrganizer(Guid id, OrganizerDetailDto updatedOrganizerDto);
        Task<CommandResult> DeleteOrganizer(Guid id);
    }

    public class OrganizerService : IOrganizerService
    {
        private readonly IGenericRepositoryAsync<Organizer> _organizerRepository;
        private readonly IMapper _mapper;

        Expression<Func<Organizer, object>>[] includes = new Expression<Func<Organizer, object>>[] { };

        public OrganizerService(IGenericRepositoryAsync<Organizer> organizerRepository, IMapper mapper)
        {
            _organizerRepository = organizerRepository;
            _mapper = mapper;
        }

        public async Task<CommandResult<IEnumerable<OrganizerDetailDto>>> GetOrganizers()
        {
            var organizerList = await _organizerRepository.GetAllAsync(includes);
            var data = _mapper.Map<IEnumerable<OrganizerDetailDto>>(organizerList);
            return new SuccessCommandResult<IEnumerable<OrganizerDetailDto>>(data);
        }

        public async Task<CommandResult<OrganizerDetailDto>> GetOrganizerById(Guid id)
        {
            var organizer = await _organizerRepository.GetByIdAsync(id, includes);
            if (organizer == null)
            {
                return new NotFoundCommandResult<OrganizerDetailDto>("Organizer not found");
            }

            var data = _mapper.Map<OrganizerDetailDto>(organizer);
            return new SuccessCommandResult<OrganizerDetailDto>(data);
        }

        public async Task<CommandResult> AddOrganizer(OrganizerDetailDto organizerDto)
        {
            var organizer = _mapper.Map<Organizer>(organizerDto);
            await _organizerRepository.AddAsync(organizer);
            return new SuccessCommandResult("Organizer added successfully");
        }

        public async Task<CommandResult> UpdateOrganizer(Guid id, OrganizerDetailDto updatedOrganizerDto)
        {
            var organizer = await _organizerRepository.GetByIdAsync(id);
            if (organizer == null)
            {
                return new NotFoundCommandResult("Organizer not found");
            }

            _mapper.Map(updatedOrganizerDto, organizer);
            await _organizerRepository.UpdateAsync(organizer);
            return new SuccessCommandResult("Organizer updated successfully");
        }

        public async Task<CommandResult> DeleteOrganizer(Guid id)
        {
            var organizer = await _organizerRepository.GetByIdAsync(id);
            if (organizer == null)
            {
                return new NotFoundCommandResult("Organizer not found");
            }

            await _organizerRepository.DeleteAsync(organizer);
            return new SuccessCommandResult("Organizer deleted successfully");
        }
    }
}

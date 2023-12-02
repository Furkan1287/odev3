using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Shared.Repository;
using Shared.Utils.Result;
using System.Linq.Expressions;

namespace Application.Services
{
    public interface IStandingEventService
    {
        public Task<ICommandResult> CreateEventAsync(StandingEventCreateDto eventItem);
        public Task<ICommandResult> DeleteEventAsync(Guid id);
        public Task<ICommandResult> UpdateEventAsync(StandingEvent eventItem);
        public Task<ICommandResult<StandingEventDetailDto>> GetEventByIdAsync(Guid id);
        public Task<ICommandResult<IEnumerable<StandingEventDetailDto>>> GetEventsAsync();
    }

    public class StandingEventService : IStandingEventService
    {
        private readonly IGenericRepositoryAsync<StandingEvent> _standingEventRepository;
        readonly IMapper _mapper;

        Expression<Func<StandingEvent, object>>[] includes = new Expression<Func<StandingEvent, object>>[]
        {
            s => s.Category,
            s => s.Organizer,
            s => s.Venue,
            s => s.Images
        };

        public StandingEventService(IGenericRepositoryAsync<StandingEvent> standingEventRepository, IMapper mapper)
        {
            _standingEventRepository = standingEventRepository;
            _mapper = mapper;
        }
        #region crud operations
        public async Task<ICommandResult> CreateEventAsync(StandingEventCreateDto eventItem)
        {
            var entity = _mapper.Map<StandingEvent>(eventItem);

            if (eventItem.IsFree)
            {
                entity.Price = null;
            }
            await _standingEventRepository.AddAsync(entity);
            return new SuccessCommandResult();
        }

        public async Task<ICommandResult> DeleteEventAsync(Guid id)
        {
            var deleteEvent = await _standingEventRepository.GetAsync(e => e.Id == id);
            if (deleteEvent != null)
            {
                await _standingEventRepository.DeleteAsync(deleteEvent);
                return new SuccessCommandResult();
            }
            return new ErrorCommandResult();
        }

        public async Task<ICommandResult<StandingEventDetailDto>> GetEventByIdAsync(Guid id)
        {
            var existEvent = await _standingEventRepository.GetAsync(e => e.Id == id, includes);
            if (existEvent != null)
            {
                var data = _mapper.Map<StandingEventDetailDto>(existEvent);
                return new SuccessCommandResult<StandingEventDetailDto>(data);
            }
            return new ErrorCommandResult<StandingEventDetailDto>(); 
        }

        public async Task<ICommandResult<IEnumerable<StandingEventDetailDto>>> GetEventsAsync()
        {
            var eventList = await _standingEventRepository.GetAllAsync(includes);

            var data = new List<StandingEventDetailDto>();
            foreach (var item in eventList)
            {
                var entity = _mapper.Map<StandingEventDetailDto>(item);
                data.Add(entity);
            }
            return new SuccessCommandResult<IEnumerable<StandingEventDetailDto>>(data);
        }

        public async Task<ICommandResult> UpdateEventAsync(StandingEvent eventItem)
        {
            var existEvent = await _standingEventRepository.GetAsync(e => e.Id == eventItem.Id);
            if (existEvent != null)
            {
                await _standingEventRepository.UpdateAsync(existEvent);
                return new SuccessCommandResult();
            }
            return new ErrorCommandResult();
        }
        #endregion
    }
}

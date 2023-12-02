using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using Shared.Repository;
using Shared.Utils.Helper;
using Shared.Utils.Result;

namespace Application.Services
{
    public interface IEventImageService
    {
        Task<CommandResult> UploadImage(EventImageUploadDto eventImage);
        Task<CommandResult> DeleteImage(Guid imageId);
    }
    public class EventImageService : IEventImageService
    {
        readonly IGenericRepositoryAsync<EventImage> _eventImageRepository;
        readonly IMapper _mapper;

        public EventImageService(IGenericRepositoryAsync<EventImage> eventImageRepository, IMapper mapper)
        {
            _eventImageRepository = eventImageRepository;
            _mapper = mapper;
        }

        public async Task<CommandResult> DeleteImage(Guid imageId)
        {
            var deleteEventImage = await _eventImageRepository.GetAsync(i => i.Id == imageId);
            if (deleteEventImage is not null)
            {
                await _eventImageRepository.DeleteAsync(deleteEventImage);
                return new SuccessCommandResult();
            }
            return new ErrorCommandResult("Resim bulunamadı!");
        }

        public async Task<CommandResult> UploadImage(EventImageUploadDto eventImageDto)
        {
            if (eventImageDto.Images.Count() > 3 )
            {
                return new ErrorCommandResult("3' den fazla resim yüklenemez!");
            }
            if (eventImageDto.Images.Count() < 0)
            {
                //var defaultImage = await _eventImageRepository.GetAsync(i => i.Id == Guid.NewGuid());
                return new SuccessCommandResult();
            }

            var eventImage = _mapper.Map<EventImage>(eventImageDto);
            foreach (var image in eventImageDto.Images)
            {
                var item = ImageHelper.ImageToBase64(image);

                if (item != null)
                {
                    eventImage.ImageUrl = item;
                    await _eventImageRepository.AddAsync(eventImage);
                }
            }
            
            return new SuccessCommandResult();
        }
    }
}

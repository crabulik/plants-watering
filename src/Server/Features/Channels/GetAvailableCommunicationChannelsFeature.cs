using AutoMapper;
using PlantsWatering.Server.Services.Repositories;
using PlantsWatering.Shared.Dtos.Channels;

namespace PlantsWatering.Server.Features.Channels
{
    public class GetAvailableCommunicationChannelsFeature : IGetAvailableCommunicationChannelsFeature
    {
        private readonly IChannelsRepository _channelsRepository;
        private readonly IMapper _mapper;

        public GetAvailableCommunicationChannelsFeature(IChannelsRepository channelsRepository, IMapper mapper)
        {
            _channelsRepository = channelsRepository ?? throw new ArgumentNullException(nameof(channelsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetAvailableCommunicationChannelsResponceDto> HandleAsync()
        {
            var unusedChannels = await _channelsRepository.GetUnusedChannelsAsync();

            return new GetAvailableCommunicationChannelsResponceDto
            {
                CommunicationChannels = _mapper.Map<CommunicationChannelDto[]>(unusedChannels)
            };
        }
    }
}

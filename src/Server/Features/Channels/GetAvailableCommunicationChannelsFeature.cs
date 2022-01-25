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
            _channelsRepository = channelsRepository;
            _mapper = mapper;
        }

        public async Task<CommunicationChannelDto[]> HandleAsync()
        {
            var unusedChannels = await _channelsRepository.GetUnusedChannelsAsync();

            return _mapper.Map<CommunicationChannelDto[]>(unusedChannels);  
        }
    }
}

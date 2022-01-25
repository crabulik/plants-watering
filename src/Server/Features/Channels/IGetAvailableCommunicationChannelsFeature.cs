using PlantsWatering.Shared.Dtos.Channels;

namespace PlantsWatering.Server.Features.Channels
{
    public interface IGetAvailableCommunicationChannelsFeature
    {
        public Task<CommunicationChannelDto[]> HandleAsync();
    }
}

namespace PlantsWatering.Shared.Dtos.Channels
{
    public class GetAvailableCommunicationChannelsResponceDto
    {
        public CommunicationChannelDto[] CommunicationChannels { get; set; } = new CommunicationChannelDto[0];
    }
}
